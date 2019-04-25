using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kitchen.mealWeek;
using Kitchen.Meal;
namespace Kitchen.pages
{
    /// <summary>
    /// Interaction logic for mealPlanner.xaml
    /// </summary>
    public partial class mealPlanner : Page
    {
        public event EventHandler PageFinished;
        public int choiceArray;
        MealWeek mealWeek;
        List<Recipe> recipes;
        List<string> recipeNames;
        ComboBox[] breakFastArray;
        ComboBox[] lunchArray;
        ComboBox[] dinnerArray;
        public mealPlanner()
        {
            InitializeComponent();
            
            recipes = Kitchen_Database.Recipes;
            mealWeek = Kitchen_Database.PlannedMeals;
            recipeNames = new List<string>();
            breakFastArray = new ComboBox[7];
            lunchArray = new ComboBox[7];
            dinnerArray = new ComboBox[7];

            loadRecipes();
            loadView();

        }
        public void loadRecipes()
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                recipeNames.Add(recipes.ElementAt(i).Name);
            }
        }
        public void loadView()
        {
            Recipe temp;
            string tempName;
            for (int i = 0; i < 7; i++)
            {
                Border border = new Border();
                border.Background = Brushes.GhostWhite;
                border.BorderBrush = Brushes.Gainsboro;
                border.BorderThickness = new Thickness(1);
                border.Margin = new Thickness(0, 0, 10, 0);
                border.Name = "b" + (i+1).ToString();

                StackPanel stackPanel = new StackPanel();
                stackPanel.Margin = new Thickness(5);
                
                //textblock for day of the week
                TextBlock day = new TextBlock();
                day.Text = mealWeek.DaysOfWeek[i].ToString() + ":";
                day.Background = Brushes.Transparent;
                day.FontWeight = FontWeights.Bold;
                day.Margin = new Thickness(0, 0, 0, 10);

                TextBlock breakfast = new TextBlock();
                breakfast.Text = "Breakfast";
                breakfast.Background = Brushes.Transparent;
                breakfast.FontWeight = FontWeights.Bold;

                breakFastArray[i] = new ComboBox();
                breakFastArray[i].ItemsSource = recipeNames;
                temp = mealWeek.getMeal(Meals.Breakfast, i);
                tempName = temp.Name;
                if (recipeNames.Contains(tempName))
                {
                    breakFastArray[i].SelectedValue = tempName;
                }

                TextBlock lunch = new TextBlock();
                lunch.Text = "Lunch";
                lunch.Background = Brushes.Transparent;
                lunch.FontWeight = FontWeights.Bold;

                lunchArray[i] = new ComboBox();
                lunchArray[i].ItemsSource = recipeNames;
                temp = mealWeek.getMeal(Meals.Lunch, i);
                tempName = temp.Name;
                if (recipeNames.Contains(tempName))
                {
                    lunchArray[i].SelectedValue = tempName;
                }

                TextBlock dinner = new TextBlock();
                dinner.Text = "Dinner";
                dinner.Background = Brushes.Transparent;
                dinner.FontWeight = FontWeights.Bold;

                dinnerArray[i] = new ComboBox();
                dinnerArray[i].ItemsSource = recipeNames;
                temp = mealWeek.getMeal(Meals.Dinner, i);
                tempName = temp.Name;
                if (recipeNames.Contains(tempName))
                {
                    dinnerArray[i].SelectedValue = tempName;
                }

                stackPanel.Children.Add(day);
                stackPanel.Children.Add(breakfast);
                stackPanel.Children.Add(breakFastArray[i]);
                stackPanel.Children.Add(lunch);
                stackPanel.Children.Add(lunchArray[i]);
                stackPanel.Children.Add(dinner);
                stackPanel.Children.Add(dinnerArray[i]);

                border.Child = stackPanel;

                Grid.SetColumn(border, i + 2);
                Grid.SetRow(border, 4);

                TheGrid.Children.Add(border);
            }
        }
        public void submitPlanner(object sender, RoutedEventArgs e)
        {
            choiceArray = 2;
            for (int i = 0; i < 7; i++)
            {
                string bRecipeName = breakFastArray[i].SelectionBoxItem.ToString();
                string lRecipeName = lunchArray[i].SelectionBoxItem.ToString();
                string dRecipeName = dinnerArray[i].SelectionBoxItem.ToString();

                Recipe bRecipe = new Recipe();
                for (int x = 0; x < recipes.Count; x++)
                {
                    if (recipes.ElementAt(x).Name == bRecipeName)
                    {
                        bRecipe = recipes.ElementAt(x);
                    }
                }

                Recipe lRecipe = new Recipe();
                for (int x = 0; x < recipes.Count; x++)
                {
                    if (recipes.ElementAt(x).Name == lRecipeName)
                    {
                        lRecipe = recipes.ElementAt(x);
                    }
                }

                Recipe dRecipe = new Recipe();
                for (int x = 0; x < recipes.Count; x++)
                {
                    if (recipes.ElementAt(x).Name == dRecipeName)
                    {
                        dRecipe = recipes.ElementAt(x);
                    }
                }

                mealWeek.setMeal(Meals.Breakfast, i, bRecipe);
                mealWeek.setMeal(Meals.Lunch, i, lRecipe);
                mealWeek.setMeal(Meals.Dinner, i, dRecipe);
            }
            
            PageFinished(new object(), new EventArgs());
        }
        public void clear(object sender, RoutedEventArgs e)
        {
            choiceArray = 1;
            PageFinished(new object(), new EventArgs());
        }
    }
}
