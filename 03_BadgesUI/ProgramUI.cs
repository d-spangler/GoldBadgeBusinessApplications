using _03_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesUI
{
    public class ProgramUI
    {
        public BadgesRepo _badgesRepo = new BadgesRepo();

        public void Run()
        {
            BadgeSeedList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;

            while (continueToRun)
            {
                Console.WriteLine("Hello Security Admin. What would you like to do? \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges \n" +
                    "4. Exit \n");

                string adminInput = Console.ReadLine();

                switch (adminInput)
                {
                    case "1":
                        {
                            AddBadge();
                            break;
                        }
                    case "2":
                        {
                            EditBadge();
                            break;
                        }
                    case "3":
                        {
                            ListAllBadges();
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

        //I spent 2.5 days working on this AddBadge, EditBadge part and couldn't figure it out 100%.//
        //I gave up when I decided I needed to focus on the portfolio...//
        
        //AddBadge()//
        private void AddBadge()
        {
            Console.Clear();
            BadgesContent badge = new BadgesContent();

            Console.WriteLine("What is the number on the badge: ");
            badge.BadgeId = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door that it needs access to: ");
            badge.DoorId = Console.ReadLine().ToUpper();

            bool continueAddingDoors = true;
            while (continueAddingDoors)
            {
                Console.WriteLine("Any other doors (y/n)? ");
                string adminInput = Console.ReadLine().ToLower();

                if (adminInput == "y")
                {
                    Console.WriteLine("List a door that it needs access to: ");
                    string doorAccess = Console.ReadLine().ToUpper();
                    badge.DoorId = badge.DoorId + "," + doorAccess;
                }
                else
                {
                    Console.WriteLine("Returning to main menu. \n");
                    continueAddingDoors = false;
                }
            }

            bool added = _badgesRepo.AddNewBadgeToDirectory(badge.BadgeId, badge.DoorId);

            Console.WriteLine("Your badge has been added. \n" +
                "Press any key to continue... \n");
            Console.ReadKey();

            //I couldn't get this entire if/else section to work properly.//
            //It always just skipped right over if and wrote that somthing went wrong,//
            //even though the badge was added to the directory...//
            /*
            if (added == true)
            {
                Console.WriteLine("Your badge has been added. \n" +
                    "Press any key to continue... \n");
                Console.ReadKey();
            }
            
            else
            {
                Console.WriteLine("Something went wrong, please try again. \n" +
                    "Press any key to continue... \n");
                Console.ReadKey();
            }*/

        }

     
        //EditBadge()//
        private void EditBadge()
        {
            BadgesContent newDoorAccess = new BadgesContent();
            Dictionary<int, string> listOfBadges = _badgesRepo.GetBadges();


            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("What is the badge number to update?");
                int badgeId = int.Parse(Console.ReadLine());
                

                BadgesContent badgeToBeUpdated = _badgesRepo.GetBadgeById(badgeId);
                
                if(listOfBadges.ContainsKey(badgeId))
                {
                    Console.WriteLine("Badge#{0}    DoorAccess: {1} \n", badgeToBeUpdated.BadgeId, badgeToBeUpdated.DoorId);
                }

                Console.WriteLine("What would you like to do? \n" +
                    "1. Remove a door \n" +
                    "2. Add a door \n" +
                    "3. Return to main menu \n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    //Remove access//
                    case "1":
                        {
                            Console.WriteLine("Which door would you like to remove?");
                            string doorToBeRemoved = Console.ReadLine();
                            
                            _badgesRepo.RemoveDoorAccessToId(badgeId, doorToBeRemoved, newDoorAccess);

                            bool updated = _badgesRepo.UpdateBadge(badgeId, newDoorAccess);
                            if(updated)
                            {
                                Console.WriteLine("Door removed. \n");
                                Console.WriteLine("{0} has access to door(s) {1}", badgeId, newDoorAccess.DoorId);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("There has been an error, please try again.");
                                Console.ReadKey();
                            }

                            DisplayBadge(newDoorAccess);

                            Console.WriteLine("Press any key to continue... \n");
                            Console.ReadKey();

                            _badgesRepo.UpdateBadge(badgeId, newDoorAccess);

                            

                            continueToRun = false;
                            break;
                        }

                    //Add Access//
                    case "2":
                        {
                            Console.WriteLine("Which door would you like to add?");
                            string updatedDoorId = Console.ReadLine().ToUpper();

                            _badgesRepo.AddDoorAccessToId(badgeId, updatedDoorId, newDoorAccess);


                            Console.WriteLine("Door added. \n");

                            Console.WriteLine("{0} has access to door(s) {1}", badgeId, newDoorAccess.DoorId);

                            continueToRun = false;
                            break;
                        }
                    //Exit//
                    case "3":
                        {
                            continueToRun = false;
                            break;
                        }
                
                }
            }
            
            Console.WriteLine("Press any key to continue... \n");
            Console.ReadKey();

        }

        //ListAllBadges()//
        private void ListAllBadges()
        {
            Dictionary<int, string> listOfBadges = _badgesRepo.GetBadges();
            Console.WriteLine();
            foreach(KeyValuePair<int, string> badgeKeyValuePair in listOfBadges)
            {
                Console.WriteLine("Badge#{0}    DoorAccess: {1}", badgeKeyValuePair.Key, badgeKeyValuePair.Value);
            }

            Console.WriteLine("Press any key to continue... \n");
            Console.ReadKey();
            
        }

        //Display badge information//
        private void DisplayBadge(BadgesContent badge)
        {
            Console.WriteLine("Badge# {0}, Door Access {1}", badge.BadgeId, badge.DoorId);
        }

        //Existing badge information//
        private void BadgeSeedList()
        {
            _badgesRepo.AddNewBadgeToDirectory(54321, "A7");
            _badgesRepo.AddNewBadgeToDirectory(22345, "A1,A4,B1,B2");
            _badgesRepo.AddNewBadgeToDirectory(32345, "A4,A5");

        }
    }
}
