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

        //  Constructor ///////////////////////////////////////////////////////////////////////////

        static Kitchen_Database()
        {
            m_Inventory = new List<Ingredient>();
            m_RecipeList = new List<Recipe>();
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

        //  Public Functions    ///////////////////////////////////////////////////////////////////

        public static int Add_IngredientToInventory(Ingredient newIngredient)
        {
            //Add new ingredient to end of inventory list
            m_Inventory.Add(newIngredient);
            return m_Inventory.Count;
        }

        public static int Use_IngredientInInventory(Ingredient usedIngredient)
        {
            //Find the ingredient within the inventory
            return 0;
        }
    }
}
