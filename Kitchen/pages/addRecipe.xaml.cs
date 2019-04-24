using Kitchen.Inventory;
using Kitchen.Meal;
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


namespace Kitchen.pages
{
    /// <summary>
    /// Interaction logic for addRecipe.xaml
    /// </summary>
    public partial class addRecipe : Page
    {
        public event EventHandler PageFinished;
        public int choiceArray;
        public Recipe m_recipe;

        public addRecipe()
        {
            InitializeComponent();
            m_recipe = new Recipe();
        }

        public void loadSteps() {
            List<string> sStepList = m_recipe.Steps;

            for(int i=0; i<sStepList.Count; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = sStepList[i];
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
            List<Ingredient> ingredientList = m_recipe.Ingredients;

            for (int i=0; i < ingredientList.Count; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = ingredients.ElementAt(i).Name;
                Grid.SetRow(textBlock, i + 4);
                Grid.SetColumn(textBlock, 6);
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
            m_recipe.Add_Step(step);

            StepToAdd.Text = "";

            Refresh();
        }

        public void addIngredientToRecipe(object sender, RoutedEventArgs e) {
            if (IngredientNameToAdd.Text == "")
            {
                //maybe add popup to add text
                return;
            }
            Measurement newMeasurement = new Measurement(int.Parse(IngredientQuantityToAdd.Text),
                                                            IngredientQuantityToAdd.Text);

            Ingredient newIngredient = new Ingredient(newMeasurement, 
                                                        IngredientNameToAdd.Text, 
                                                        IngredientDescriptionToAdd.Text);

            m_recipe.Add_Ingredient(newIngredient);

            IngredientNameToAdd.Text = "";
            IngredientQuantityToAdd.Text = "";
            IngredientDescriptionToAdd.Text = "";

            Refresh();
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

        private void Refresh()
        {
            loadSteps();
            loadIngredients();
        }

        private void RecipeName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
