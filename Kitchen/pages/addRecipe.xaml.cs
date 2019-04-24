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
using static Kitchen.Globals;
namespace Kitchen.pages
{
    /// <summary>
    /// Interaction logic for addRecipe.xaml
    /// </summary>
    public partial class addRecipe : Page
    {
        public event EventHandler PageFinished;
        public int choiceArray;
        LinkedList<string> steps;
        LinkedList<Ingredient> ingredients;
        public addRecipe()
        {
            InitializeComponent();
            steps = new LinkedList<string>();
            ingredients = new LinkedList<Ingredient>();
        }
        public void loadSteps() {
            int stepCount = steps.Count;
            for(int i = 0;i<stepCount;i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = steps.ElementAt(i);
                Grid.SetRow(textBlock, i + 4);
                Grid.SetColumn(textBlock, 5);
                //textBlock.FontWeight = FontWeights.Bold;
                textBlock.Background = Brushes.Transparent;
                textBlock.Margin = new Thickness(0, 0, 10, 10);
                textBlock.MinWidth = 100;
                textBlock.MaxWidth = 150;
                textBlock.TextWrapping = TextWrapping.Wrap;
                TheGrid.Children.Add(textBlock);
            }
        }
        public void loadIngredients() {
            int ingredientCount = ingredients.Count;
            for (int i = 0; i < ingredientCount; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = ingredients.ElementAt(i).Measurement + " " + ingredients.ElementAt(i).Name;
                Grid.SetRow(textBlock, i + 4);
                Grid.SetColumn(textBlock, 6);
                //textBlock.FontWeight = FontWeights.Bold;
                textBlock.Background = Brushes.Transparent;
                textBlock.Margin = new Thickness(0, 0, 10, 10);
                textBlock.MinWidth = 100;
                textBlock.MaxWidth = 100;
                textBlock.TextWrapping = TextWrapping.Wrap;
                TheGrid.Children.Add(textBlock);
            }
        }
        public void addStepToRecipe(object sender, RoutedEventArgs e) {
            if (StepToAdd.Text == "")
            {
                return;
            }
            string step = StepToAdd.Text;
            steps.AddLast(step);
            StepToAdd.Text = "";
            loadSteps();
        }
        public void addIngredientToRecipe(object sender, RoutedEventArgs e) {
            if (IngredientNameToAdd.Text == "")
            {
                //maybe add popup to add text
                return;
            }
            Ingredient newIngredient = new Ingredient(IngredientNameToAdd.Text, IngredientQuantityToAdd.Text, IngredientDescriptionToAdd.Text);
            ingredients.AddLast(newIngredient);
            IngredientNameToAdd.Text = "";
            IngredientQuantityToAdd.Text = "";
            IngredientDescriptionToAdd.Text = "";
            loadIngredients();
        }
        public void submitRecipe(object sender, RoutedEventArgs e) {
            if (RecipeName.Text == "")
            {
                System.Console.WriteLine("submit failed");
                return;
            }
            choiceArray = 2;
            string recipeName = RecipeName.Text;
            string recipeDescription = RecipeDescription.Text;

            Recipe recipe = new Recipe(recipeName, recipeDescription, ingredients, steps);
            userData.addRecipe(recipe);
            PageFinished(new object(), new EventArgs());
            System.Console.WriteLine("Submit suceeded");
            
        }
    }
}
