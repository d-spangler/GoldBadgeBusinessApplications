using _02_Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsUI
{
    public class ProgramUI
    {
        private readonly ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            ClaimDirectorySeedList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("What would you like to do: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            SeeAll();
                            break;
                        }
                    case "2":
                        {
                            NextClaim();
                            break;
                        }
                    case "3":
                        {
                            NewClaim();
                            break;
                        }
                    case "4":
                        {
                            continueToRun = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void SeeAll()
        {
            Queue<ClaimsContent> listOfClaims = _claimsRepo.GetClaims();
            if(listOfClaims.Count > 0)
            {
                foreach(ClaimsContent claim in listOfClaims)
                {
                DisplayClaim(claim);
                }
            }
            else
            {
                Console.WriteLine("There are no open claims at this time. \n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void NextClaim()
        {
            Queue<ClaimsContent> claimsList = _claimsRepo.GetClaims();
            
            while(claimsList.Count > 0)
            {
                DisplayClaim(claimsList.Peek());
                Console.WriteLine("Do you want to deal with this claim now (y/n)?");

                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "y":
                        {
                            claimsList.Dequeue();
                            RunMenu();
                            break;
                        }
                    case "n":
                        {
                            RunMenu();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void NewClaim()
        {
            ClaimsContent claim = new ClaimsContent();

            Console.WriteLine("Enter the new Claim ID number: ");
            claim.ClaimId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select a claim type: \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft \n");
            string claimTypeChoice = Console.ReadLine();
            int type = int.Parse(claimTypeChoice);
            claim.ClaimType = (TypeOfClaim)type;

            Console.WriteLine("Enter a description: ");
            claim.ClaimDescription = Console.ReadLine();

            Console.WriteLine("Enter the claim amount (in X.XX form): ");
            claim.DollarAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("What was the date of the accident? \n" +
                "Please use format: MM, DD, YYYY\n" +
                "Example: 01, 13, 2000 \n");
            string aDate = Console.ReadLine();
            claim.DateOfAccident = DateTime.Parse(aDate);

            Console.WriteLine("What was the date the claim was submitted? \n" +
                "Please use format: MM, DD, YYYY\n" +
                "Example: 01, 13, 2000 \n");
            string cDate = Console.ReadLine();
            claim.DateOfClaim = DateTime.Parse(cDate);

            DateTime accident = Convert.ToDateTime(aDate);
            DateTime submitted = Convert.ToDateTime(cDate);
            TimeSpan difference = submitted - accident;


            if(difference.Days < 30)
            {
                Console.WriteLine($"The claim was made {difference.Days} after the accident occurred.\n");
                claim.IsValid = true;
            }
            else
            {
                Console.WriteLine($"The claim was made {difference.Days} after the accident occurred.\n");
                claim.IsValid = false;
            }

            bool added = _claimsRepo.AddClaimToDirectory(claim);
            if (added)
            {
                Console.WriteLine("The claim has been added successfully. \n" +
                    "Press any key to continue...\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There has been an error, please try again.\n");
                Console.ReadKey();
                NewClaim();
            }
        }

        private void DisplayClaim(ClaimsContent claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimId} \n" +
                $"Type: {claim.ClaimType} \n" +
                $"Description: {claim.ClaimDescription} \n" +
                $"Amount: ${claim.DollarAmount} \n" +
                $"Date of Accident: {claim.DateOfAccident} \n" +
                $"Date of Claim: {claim.DateOfClaim} \n" +
                $"Is Valid: {claim.IsValid} \n" +
                $"\n");
        }

        private void ClaimDirectorySeedList()
        {
            ClaimsContent firstClaim = new ClaimsContent(1, TypeOfClaim.Car, "Car accident on 465.", 400.00m, 
                new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            _claimsRepo.AddClaimToDirectory(firstClaim);
            ClaimsContent secondClaim = new ClaimsContent(2, TypeOfClaim.Home, "House fire in kitchen.", 4000.00m, 
                new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            _claimsRepo.AddClaimToDirectory(secondClaim);
            ClaimsContent thirdClaim = new ClaimsContent(3, TypeOfClaim.Theft, "Stolen pancakes.", 4.00m, 
                new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);
            _claimsRepo.AddClaimToDirectory(thirdClaim);
        }
    }
}
