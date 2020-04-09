using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuContent
    {
        public int MealNumber { get; set; }//So the user can say "I'll have the #5."//
        public string MealName { get; set; }//So the user may order by name.//
        public string MealDescription { get; set; }//So the user knows what they're ordering.//
        public string MealIngredients { get; set; }//So the user knows what's inside.//
        public decimal MealPrice { get; set; }//Decimal to allow for dollars AND cents.//

        public MenuContent() { } //Empty constructor because of the overloaded constructor.//

        public MenuContent(int mealNumber, string mealName, string mealDescription, string mealIngredients, decimal mealPrice)
        //Overloaded constructor.//
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }


    }
}
