using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
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
}