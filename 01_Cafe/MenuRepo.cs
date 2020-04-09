using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepo
        //The manager needs to be able to add, delete, and see all menu items.//
        //The user needs to be able to order via menu item number.//
    {
        protected readonly List<MenuContent> _menuContentListing = new List<MenuContent>();

        //Add a menu item.//
        public bool AddItemToListing(MenuContent item)
        {
            int startingCount = _menuContentListing.Count;
            _menuContentListing.Add(item);
            bool wasAdded = (_menuContentListing.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Delete a menu item.//
        public bool DeleteItemFromListing(MenuContent item)
        {
            bool deleteItem = _menuContentListing.Remove(item);
            return deleteItem;
        }

        //See the entire offering.//
        public List<MenuContent> GetMenuContentListing()
        {
            return _menuContentListing;
        }

        public MenuContent OrderByNumber(int mealNumber)
        {
            foreach(MenuContent item in _menuContentListing)
            {
                if(item.MealNumber.Equals(mealNumber))
                {
                    return item;
                }
            }

            return null;
        }
    }
}
