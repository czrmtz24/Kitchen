using Kitchen.Inventory;
using Kitchen.Meal;
using Kitchen.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    public static class Kitchen_Database
    {
        //  Members ///////////////////////////////////////////////////////////////////////////////

        private static List<Ingredient> m_Inventory;
        private static List<Recipe> m_RecipeList;
        private static mealWeek.MealWeek m_MealWeek;
        private static List<Ingredient> shoppingList;
        //  Constructor ///////////////////////////////////////////////////////////////////////////

        static Kitchen_Database()
        {
            m_Inventory = Kitchen.Storage.Storage.Load_Inventory();
            m_RecipeList = Kitchen.Storage.Storage.Load_Recipes();
            m_MealWeek = new mealWeek.MealWeek(System.DateTime.Now.DayOfWeek);
            shoppingList = new List<Ingredient>();
        }

        //  Properties  ///////////////////////////////////////////////////////////////////////////

        public static List<Ingredient> Inventory
        {
            get { return m_Inventory; }
            set { m_Inventory = value; }
        }

        public static List<Recipe> Recipes
        {
            get { return m_RecipeList; }
            set { m_RecipeList = value; }
        }

        public static mealWeek.MealWeek PlannedMeals
        {
            get { return m_MealWeek; }
            set { m_MealWeek = value; }
        }
        public static List<Ingredient> ShoppingList {
            get { return shoppingList; }
            set { shoppingList = value; }
        }

        //  Public Functions    ///////////////////////////////////////////////////////////////////

        public static void SaveData()
        {
            Kitchen.Storage.Storage.Store_Inventory(m_Inventory);
            Kitchen.Storage.Storage.Store_Recipes(m_RecipeList);
        }
        
        public static int Add_IngredientToInventory(Ingredient newIngredient)
        {
            //Add new ingredient to end of inventory list
            m_Inventory.Add(newIngredient);
            return m_Inventory.Count;
        }

        public static int Add_RecipeToList(Recipe newRecipe)
        {
            //Add new recipe to end of inventory list
            m_RecipeList.Add(newRecipe);
            return m_RecipeList.Count;
        }

        public static float Use_IngredientInInventory(Ingredient usedIngredient)
        {
            //Find the ingredient within the inventory
            //int ingredientLoc = m_Inventory.IndexOf(usedIngredient);
            int ingredientLoc = -1;
            for (int i = 0; i < m_Inventory.Count; i++)
            {
                if (usedIngredient.Name == m_Inventory[i].Name)
                    ingredientLoc = i;
            }

            if (ingredientLoc > -1) //If the ingredient is found within the list
            {
                //Calculate the amount of this ingredient left over and return
                Ingredient currIngredient = new Ingredient(m_Inventory[ingredientLoc].Amount, m_Inventory[ingredientLoc].Description, m_Inventory[ingredientLoc].Name);

                return usedIngredient.Amount.MeasurementAmount - currIngredient.Amount.MeasurementAmount;
            }
            else                    //Else
                return usedIngredient.Amount.MeasurementAmount; //Return the total amount of this ingredient, negated
        }

        //  Private Functions   ///////////////////////////////////////////////////////////////////

    }
}
