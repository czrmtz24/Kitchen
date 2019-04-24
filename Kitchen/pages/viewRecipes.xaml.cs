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
using static Kitchen.Kitchen_Database;
using Kitchen.Inventory;
using Kitchen.Meal;

namespace Kitchen.pages
{
    /// <summary>
    /// Interaction logic for viewRecipes.xaml
    /// </summary>
    
    public partial class viewRecipes : Page
    {
        public string recipeName;
        public event EventHandler PageFinished;
        public viewRecipes()
        {
            InitializeComponent();
            loadRecipe();
        }
        public void loadRecipe()
        {
            if (this.recipeName == "")
            {
                return;
            }
            List<Recipe> recipes = Kitchen_Database.Recipes;
            Recipe recipe = new Recipe();
            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipes.ElementAt(i).Name == recipeName)
                {
                    recipe = recipes.ElementAt(i);
                }

            }
            if (recipe == null)
            {
                return;
            }
            RecipeName.Text = recipeName;
            RecipeDescription.Text = recipe.Description;

            TextBlock stepsHeader = new TextBlock();
            stepsHeader.Text = "Steps:";
            Grid.SetRow(stepsHeader, 4);
            Grid.SetColumn(stepsHeader, 2);
            stepsHeader.FontWeight = FontWeights.Bold;
            stepsHeader.Background = Brushes.Transparent;
            stepsHeader.Margin = new Thickness(0, 0, 10, 10);
            stepsHeader.MinWidth = 150;
            stepsHeader.FontSize = 24;
            stepsHeader.VerticalAlignment = VerticalAlignment.Center;
            stepsHeader.TextDecorations = TextDecorations.Underline;
            TheGrid.Children.Add(stepsHeader);

            TextBlock ingredientsHeader = new TextBlock();
            ingredientsHeader.Text = "Ingredients:";
            Grid.SetRow(ingredientsHeader, 4);
            Grid.SetColumn(ingredientsHeader, 3);
            ingredientsHeader.FontWeight = FontWeights.Bold;
            ingredientsHeader.Background = Brushes.Transparent;
            ingredientsHeader.Margin = new Thickness(0, 0, 10, 10);
            ingredientsHeader.MinWidth = 100;
            ingredientsHeader.FontSize = 24;
            ingredientsHeader.VerticalAlignment = VerticalAlignment.Center;
            ingredientsHeader.TextDecorations = TextDecorations.Underline;
            TheGrid.Children.Add(ingredientsHeader);

            for (int i = 0; i < recipe.Ingredients.Count; i++)
            {
                TextBlock ingredient = new TextBlock();
                ingredient.Text = recipe.Ingredients.ElementAt(i).Amount.MeasurementAmount.ToString() + " " + recipe.Ingredients.ElementAt(i).Amount.UnitsOfMeasurement + " " + recipe.Ingredients.ElementAt(i).Name;
                Grid.SetRow(ingredient, i + 5);
                Grid.SetColumn(ingredient, 3);
                ingredient.Background = Brushes.Transparent;
                ingredient.Margin = new Thickness(0, 0, 10, 10);
                ingredient.MinWidth = 100;
                ingredient.MaxWidth = 150;
                ingredient.TextWrapping = TextWrapping.Wrap;
                TheGrid.Children.Add(ingredient);
            }
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                TextBlock step = new TextBlock();
                step.Text = recipe.Steps.ElementAt(i);
                Grid.SetRow(step, i + 5);
                Grid.SetColumn(step, 2);
                step.Background = Brushes.Transparent;
                step.Margin = new Thickness(0, 0, 10, 10);
                step.MinWidth = 150;
                step.MaxWidth = 200;
                step.TextWrapping = TextWrapping.Wrap;
                TheGrid.Children.Add(step);
            }
        }
        public void setText(string recipeName) {
            this.recipeName = recipeName;
            System.Console.WriteLine($"Recipe Loaded in: {this.recipeName}");
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            List<Recipe> recipes = Kitchen_Database.Recipes;
            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipes.ElementAt(i).Name == recipeName)
                {
                    recipes.RemoveAt(i);
                    PageFinished(new object(), new EventArgs());
                }
            }
        }
    }
}
