using Kitchen.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Meal
{
    public class Recipe
    {
        //  Members ///////////////////////////////////////////////////////////////////////////////

        private string m_sDescription, m_sName;
        private List<string> m_sStepList;

        private List<Ingredient> m_IngredientList;

        //  Constructors    ///////////////////////////////////////////////////////////////////////

        public Recipe()
        {
            m_sName = "";
            m_sDescription = "";
            m_IngredientList = new List<Ingredient>(); ;
            m_sStepList = new List<string>();
        }
        
        public Recipe(string sName, string sDescription)
        {
            m_sName = sName;
            m_sDescription = sDescription;
            m_IngredientList = new List<Ingredient>(); ;
            m_sStepList = new List<string>();
        }

        public Recipe(string sName, string sDescription, 
                    List<Ingredient> ingredientList, 
                    List<string> sStepList)
        {
            m_sName = sName;
            m_sDescription = sDescription;
            m_IngredientList = ingredientList;
            m_sStepList = sStepList;
        }

        //  Properties  ///////////////////////////////////////////////////////////////////////////

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }

        public List<string> Steps
        {
            get { return m_sStepList; }
        }

        public List<Ingredient> Ingredients
        {
            get { return m_IngredientList; }
        }

        //  Public Functions    ///////////////////////////////////////////////////////////////////

        public int Add_Step(string newStep)
        {
            //Add a new ingredient to the end of the list
            m_sStepList.Add(newStep);
            return m_sStepList.Count;
        }

        public int Delete_Step()
        {
            //Delete the ingredient at the end of the list
            m_sStepList.RemoveAt(m_IngredientList.Count - 1);
            return m_sStepList.Count;
        }

        public int Add_Ingredient(Ingredient newIngredient)
        {
            //Add a new ingredient to the end of the list
            m_IngredientList.Add(newIngredient);
            return m_IngredientList.Count;
        }

        public int Delete_Ingredient()
        {
            //Delete the ingredient at the end of the list
            m_IngredientList.RemoveAt(m_IngredientList.Count - 1);
            return m_IngredientList.Count;
        }
    }
}
