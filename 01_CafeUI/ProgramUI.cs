using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
    public class ProgramUI
    {
        private readonly MenuRepo _menuContentListing = new MenuRepo();

        public void Run()
        {
            MenuItemSeedList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while(continueToRun)
            {
                Console.WriteLine("Please enter the number of your desired action: \n" +
                    "1) Order from the menu using our number system.\n" +
                    "2) (Managers) View the entire menu listing.\n" +
                    "3) (Managers) Add an item to the menu.\n" +
                    "4) (Managers) Remove an item from the menu.\n" +
                    "5) Exit.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            //Order via number.//
                            OrderItem();
                            break;
                        }
                    case "2":
                        {
                            //View entire menu.//
                            ViewMenuListing();
                            break;
                        }
                    case "3":
                        {
                            //Add an item.//
                            AddMenuItem();
                            break;
                        }
                    case "4":
                        {
                            //Remove an item.//
                            RemoveMenuItem();
                            break;
                        }
                    case "5":
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

        private void ShowMenuItem(MenuContent menuItem)
        {
            //Console.Clear();
            Console.WriteLine($"Meal Number: {menuItem.MealNumber} \n" +
                $"Name: {menuItem.MealName} \n" +
                $"Description: {menuItem.MealDescription} \n" +
                $"Ingredients: {menuItem.MealIngredients} \n" +
                $"Price: {menuItem.MealPrice} \n");
        }

        private void OrderItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter the number of your selected item: ");
            int mealNumber = Convert.ToInt32(Console.ReadLine());
            MenuContent desiredItem = _menuContentListing.OrderByNumber(mealNumber);
            if(desiredItem != null)
            {
                ShowMenuItem(desiredItem);
            }
            else
            {
                Console.WriteLine("I'm sorry, but you cannot have it your way at this establishment. Good day.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ViewMenuListing()
        {
            Console.Clear();
            List<MenuContent> menuListing = _menuContentListing.GetMenuContentListing();
            foreach(MenuContent menuItem in menuListing)
            {
                ShowMenuItem(menuItem);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddMenuItem()
        {
            Console.Clear();
            MenuContent menuItem = new MenuContent();

            Console.WriteLine("Please enter the menu number of the new meal: ");
            menuItem.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the name of the new meal: ");
            menuItem.MealName = Console.ReadLine();

            Console.WriteLine("Now enter a brief description of the meal: ");
            menuItem.MealDescription = Console.ReadLine();

            Console.WriteLine("And a list of ingredients: ");
            menuItem.MealIngredients = Console.ReadLine();

            Console.WriteLine("And finally a price in X.XX form: ");
            menuItem.MealPrice = Convert.ToDecimal(Console.ReadLine());

            //Successful or not?//
            bool added = _menuContentListing.AddItemToListing(menuItem);
            if (added)
            {
                Console.WriteLine("The new item has been added. \n" +
                    "Press any key to continue.");
                Console.ReadLine();
            }
        }

        private void RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Which item would you like to remove form the menu?");
            List<MenuContent> menuListing = _menuContentListing.GetMenuContentListing();
            int count = 0;

            foreach(MenuContent menuItem in menuListing)
            {
                count++;
                Console.WriteLine($"{count}.{menuItem.MealName}");
            }

            int targetItemId = int.Parse(Console.ReadLine());
            int targetIndex = targetItemId - 1;

            if(targetIndex >= 0 && targetIndex < menuListing.Count)
            {
                MenuContent desiredItem = menuListing[targetIndex];
                if (_menuContentListing.DeleteItemFromListing(desiredItem))
                {
                    Console.WriteLine($"{desiredItem.MealName} has no longer on the menu.");
                }
                else
                {
                    Console.WriteLine($"I would do anything for love, but I won't do that.");
                    RemoveMenuItem();
                }
            }
            else
            {
                Console.WriteLine("No item had that ID number.");
                Console.ReadKey();
            }
        }

        private void MenuItemSeedList()
        {
            MenuContent cheeseBurger = new MenuContent(1, "Royal w/ Cheese", "Two all beef patties, sandwiched between a poppy-seed bun with cheese in the middle. Comes with a soda and fries.", "Angus beef, wheat, dairy.", 9.99m);
            _menuContentListing.AddItemToListing(cheeseBurger);
            MenuContent ratatouille = new MenuContent(3, "Ratatouille", "Had to look this up...kinda like a casserole. It's a fried/baked vegetable dish. Served with a drink and a salad", "Onions, Zucchini, Tomatoes, Eggplant, Bellpeppers.", 13.99m);
            _menuContentListing.AddItemToListing(ratatouille);
            MenuContent lembas = new MenuContent(5, "Lembas Bread", "Made for sharing as one bit may fill you up. Sweet, buttery, simply the best.", "Butter, brown sugar, flour, magic.", 8.99m);
            _menuContentListing.AddItemToListing(lembas);
        }
    }
}
