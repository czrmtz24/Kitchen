using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Meal;

namespace Kitchen
{
    enum Meals
    {
        Breakfast = 0,
        Lunch = 1,
        Dinner = 2
    }
    class MealWeek
    {
        MealDay[] plannedMeals;
        DayOfWeek[] daysOfWeek;

        MealWeek()
        {
            daysOfWeek = new DayOfWeek[7] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };
            plannedMeals = new MealDay[7];
        }
        MealWeek (DayOfWeek startDay)
        {
            plannedMeals = new MealDay[7];
            setWeek(startDay);
        }

        void setWeek(DayOfWeek startDay)
        {
            for (int i = 0; i<7; i++)
            {
                daysOfWeek[i] = startDay;
                if (startDay != DayOfWeek.Saturday)
                    startDay += 1;
                else
                    startDay = DayOfWeek.Sunday;
            }
        }
        void setMeal(Meals mealTime, DayOfWeek dayOfWeek, Recipe recipe)
        {
            int weekIndex = 0;
            for (int i = 0; i < 7; i++)
            {
                if (daysOfWeek.ElementAt(i) == dayOfWeek)
                {
                    weekIndex = i;
                }
            }
            switch ((int) mealTime) {
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
    }
    class MealDay
    {
        PlannedMeal[] plannedMeals;
        //string dayOfWeek;

        public MealDay()
        {
            plannedMeals = new PlannedMeal[3];
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
            plannedMeals = new PlannedMeal[3] { p1, p2, p3 };
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
       //string DayOfWeek {
       //     get { return this.dayOfWeek; }
       //     set { this.dayOfWeek = value; }
       // }
    }
    class PlannedMeal
    {
        //public static readonly string[] weekDays = new string[7] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
        public static readonly string[] mealTypes = new string[3] { "Breakfast", "Lunch", "Dinner" };

        //private string dayOfWeek;
        private string mealType;
        private Recipe plannedRecipe;

        PlannedMeal() {
            //dayOfWeek = "";
            mealType = "";
            plannedRecipe = new Recipe();
        }

        PlannedMeal(DayOfWeek incWeekDay, Meals incMealType, Recipe incRecipe)
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
