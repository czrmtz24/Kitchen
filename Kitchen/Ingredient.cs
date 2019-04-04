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
    class Ingredient
    {
        private string name;
        private string description;
        private Measurement measurement;
        Ingredient() {
            this.name = "Empty Ingredient";
            this.description = "Empty Description";
        }
        Ingredient(string name)
        {
            this.name = name;
            this.description = "No Description Given Yet";
        }
        Ingredient(string name, string description) {
            this.name = name;
            this.description = description;
        }
        public string Name{ get { return this.name; } }
        public string Description { get { return this.description; } }
        void Describe() { System.Console.WriteLine(name + ": " + description); }
    }
    class Recipe
    {
        private Dictionary<Ingredient, int> ingredients;
        string[] steps;
    }
    class Day {
        private string[] timeOfDay;
        private LinkedList<Recipe> meals;
        
    }
    class Measurement {
        private string measurementType;
        private int measurementQuantity;
        private MeasurementTypes measurementTypeM;
        public string MeasurementType{ get { return this.measurementType; } set { this.measurementType = value; } }
        public int MeasurementQuantity { get { return this.measurementQuantity; } set { this.measurementQuantity = value; } }
        public MeasurementTypes MeasurementTypeM { get { return this.measurementTypeM; } set { this.measurementTypeM = value; } }
    }
}