using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen_Old
{
    enum WeekDays {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
    enum MeasurementTypes {
        grams, ounces, pounds, teaspoons, tablespoons, cups, pints, quarts, gallons
    }
    public class Ingredient
    {
        private string name;
        private string description;
        private string measurement;
        public Ingredient(string name, string m, string description)
        {
            this.name = name;
            this.description = description;
            this.measurement = m;
        }
        public Ingredient(string name, string description) {
            this.name = name;
            this.description = description;
        }
        public string Name{ get { return this.name; } set { this.name = value; } }
        public string Description { get { return this.description; } set { this.description = value; } }

        public string Measurement { get { return this.measurement; } }
        
        void Describe() { System.Console.WriteLine(name + ": " + description); }
    }
    public class Recipe
    {
        private string name;
        private string description;
        private LinkedList<Ingredient> ingredients;
        private LinkedList<string> steps;

        public Recipe(string name, string description, LinkedList<Ingredient> incIngredients, LinkedList<string> incSteps)
        {
            this.name = name;
            this.description = description;
            ingredients = new LinkedList<Ingredient>();
            foreach (Ingredient ingredient in incIngredients) {
                ingredients.AddLast(ingredient);
            }
            steps = new LinkedList<string>();
            foreach (string step in incSteps)
            {
                steps.AddLast(step);
            }
        }
        public string Name { get { return this.name; } }
        public string Description { get { return this.description; } }
        public LinkedList<Ingredient> Ingredients { get { return this.ingredients; } }
        public LinkedList<string> Steps { get { return this.steps; } }
    }
    class MealDay {
        private string[] timeOfDay;
        private LinkedList<Recipe> meals;
        
    }
    class Measurement {
        private double measurementQuantity;
        private MeasurementTypes measurementTypeM;
        public Measurement(MeasurementTypes type, double quantity) {
            this.measurementTypeM = type;
            this.measurementQuantity = quantity;
        }
        public double MeasurementQuantity { get { return this.measurementQuantity; } set { this.measurementQuantity = value; } }
        public MeasurementTypes MeasurementTypeM { get { return this.measurementTypeM; } set { this.measurementTypeM = value; } }
    }
    public class UserData {
        public LinkedList<Recipe> myRecipes;
        public LinkedList<Ingredient> myIngredients;

        public UserData()
        {
            myRecipes = new LinkedList<Recipe>();
            myIngredients = new LinkedList<Ingredient>();
        }

        public LinkedList<Recipe> MyRecipes {
            get { return this.myRecipes; }
        }
        public LinkedList<Ingredient> MyIngredients {
            get { return this.myIngredients; }
        }

        public void addRecipe(Recipe incRecipe) {
            myRecipes.AddLast(incRecipe);
        }
        public void addIngredient(Ingredient incIngredient)
        {
            myIngredients.AddLast(incIngredient);
        }
        public int deleteRecipe(string recipeName)
        {
            int count = myRecipes.Count;
            LinkedListNode<Recipe> head = myRecipes.First;
            for (int i = 0; i < count; i++)
            {
                if (head.Value.Name == recipeName)
                {
                    //delete
                    myRecipes.Remove(head);
                    return 0;
                }
                else {
                    head = head.Next;
                }
            }
            return -1;
        }
        public int deleteIngredient(string ingredientName)
        {
            int count = myIngredients.Count;
            LinkedListNode<Ingredient> head = myIngredients.First;
            for (int i = 0; i < count; i++)
            {
                if (head.Value.Name == ingredientName)
                {
                    myIngredients.Remove(head);
                    return 0;
                }
                else
                {
                    head = head.Next;
                }
            }
            return -1;
        }
    }
}