using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Meal;

namespace Kitchen.mealWeek
{
    public enum Meals
    {
        Breakfast = 0,
        Lunch = 1,
        Dinner = 2
    }
    public class MealWeek
    {
        private MealDay[] plannedMeals;
        private DayOfWeek[] daysOfWeek;

        public MealWeek()
        {
            daysOfWeek = new DayOfWeek[7] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };
            plannedMeals = new MealDay[7];
        }
        public MealWeek(DayOfWeek startDay)
        {
            plannedMeals = new MealDay[7];
            for (int i = 0; i < 7; i++)
            {
                plannedMeals[i] = new MealDay();
            }
            daysOfWeek = new DayOfWeek[7];
            setWeek(startDay);
        }

        public void setWeek(DayOfWeek startDay)
        {
            for (int i = 0; i < 7; i++)
            {
                daysOfWeek[i] = startDay;
                if (startDay != DayOfWeek.Saturday)
                    startDay += 1;
                else
                    startDay = DayOfWeek.Sunday;
            }
        }
        public void setMeal(Meals mealTime, int index, Recipe recipe)
        {
            int weekIndex = index;
            switch ((int)mealTime) {
                case 0:
                    //breakfast
                    plannedMeals.ElementAt(weekIndex).Breakfast.PlannedRecipe = recipe;
                    break;
                case 1:
                    plannedMeals.ElementAt(weekIndex).Lunch.PlannedRecipe = recipe;
                    break;
                case 2:
                    plannedMeals.ElementAt(weekIndex).Dinner.PlannedRecipe = recipe;
                    break;
            }
        }
        public Recipe getMeal(Meals mealTime, int index)
        {
            MealDay temp = plannedMeals[index];
            switch (mealTime)
            {
                case Meals.Breakfast:
                    return temp.Breakfast.PlannedRecipe;
                case Meals.Lunch:
                    return temp.Lunch.PlannedRecipe;
                case Meals.Dinner:
                    return temp.Dinner.PlannedRecipe;
                default:
                    return new Recipe();
            }
        }
        public DayOfWeek [] DaysOfWeek{
            get { return this.daysOfWeek; }        
        }
    }
    public class MealDay
    {
        private PlannedMeal[] plannedMeals;
        //string dayOfWeek;

        public MealDay()
        {
            plannedMeals = new PlannedMeal[3];
            for (int i = 0; i < 3; i++)
            {
                plannedMeals[i] = new PlannedMeal();
            }
            //this.dayOfWeek = System.DateTime.Now.DayOfWeek.ToString();
        }
        public MealDay(PlannedMeal p1, PlannedMeal p2, PlannedMeal p3)
        {
            //if ((p1.DayOfWeek == p2.DayOfWeek) && (p2.DayOfWeek == p3.DayOfWeek))
            //{
            //    dayOfWeek = p1.DayOfWeek;
            //}
            //else {
            //    dayOfWeek = "Incorrect Dates";
            //}
            this.plannedMeals = new PlannedMeal[3] { p1, p2, p3 };
        }

        public PlannedMeal Breakfast {
            get { return this.plannedMeals[0]; }
            set { this.plannedMeals[0] = value;  }
        }
        public PlannedMeal Lunch {
            get { return this.plannedMeals[1]; }
            set { this.plannedMeals[1] = value; }
        }
        public PlannedMeal Dinner {
            get { return this.plannedMeals[2]; }
            set { this.plannedMeals[2] = value; }
        }
       
    }
    public class PlannedMeal
    {
        //public static readonly string[] weekDays = new string[7] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
        public static readonly string[] mealTypes = new string[3] { "Breakfast", "Lunch", "Dinner" };

        //private string dayOfWeek;
        private string mealType;
        private Recipe plannedRecipe;

        public PlannedMeal() {
            //dayOfWeek = "";
            mealType = "";
            plannedRecipe = new Recipe();
        }

        public PlannedMeal(DayOfWeek incWeekDay, Meals incMealType, Recipe incRecipe)
        {
            //dayOfWeek = incWeekDay.ToString();
            mealType = mealTypes[(int)incMealType];
            plannedRecipe = incRecipe;
        }
        //public string DayOfWeek {
        //    get { return this.dayOfWeek; }
        //    set { this.dayOfWeek = value; }
        //}
        public string MealType {
            get { return this.mealType; }
            set { this.mealType = value; }
        }
        public Recipe PlannedRecipe {
            get { return this.plannedRecipe; }
            set { this.plannedRecipe = value; }
        }
        
    }
}
