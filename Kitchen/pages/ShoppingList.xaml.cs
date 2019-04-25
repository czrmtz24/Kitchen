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
    /// Interaction logic for ShoppingList.xaml
    /// </summary>
    public partial class ShoppingList : Page
    {
        StackPanel stackPanel;
        MealWeek mealWeek;
        public event EventHandler PageFinished;
        public ShoppingList()
        {
            InitializeComponent();
            mealWeek = Kitchen_Database.PlannedMeals;
            loadView();
        }

        public void exit(object sender, RoutedEventArgs e)
        {
            
            PageFinished(new object(), new EventArgs());
        }
        public void loadView()
        {
            stackPanel = new StackPanel();
            List<Recipe> recipes = new List<Recipe>();
            for (int i = 0; i < 7; i++)
            {
                Recipe bRecipe = mealWeek.getMeal(Meals.Breakfast, i);
                Recipe lRecipe = mealWeek.getMeal(Meals.Lunch, i);
                Recipe dRecipe = mealWeek.getMeal(Meals.Dinner, i);

                if (bRecipe.Name != "")
                {
                    for (int x = 0; x < bRecipe.Ingredients.Count; x++)
                    {
                        float amount = Kitchen_Database.Use_IngredientInInventory(bRecipe.Ingredients[x]);
                        if (amount < 0)
                            amount *= -1;
                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = bRecipe.Ingredients[x].Name + " (" + amount.ToString() + " "  + bRecipe.Ingredients[x].Amount.UnitsOfMeasurement+")";
                        textBlock.Background = Brushes.Transparent;
                        textBlock.FontWeight = FontWeights.Bold;
                        stackPanel.Children.Add(textBlock);
                    }
                }
                if (dRecipe.Name != "")
                {
                    for (int x = 0; x < lRecipe.Ingredients.Count; x++)
                    {
                        float amount = Kitchen_Database.Use_IngredientInInventory(lRecipe.Ingredients[x]);
                        if (amount < 0)
                            amount *= -1;
                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = lRecipe.Ingredients[x].Name + " (" + amount.ToString() + " " + lRecipe.Ingredients[x].Amount.UnitsOfMeasurement + ")";
                        textBlock.Background = Brushes.Transparent;
                        textBlock.FontWeight = FontWeights.Bold;
                        stackPanel.Children.Add(textBlock);
                    }
                }
                if (lRecipe.Name != "")
                {
                    for (int x = 0; x < dRecipe.Ingredients.Count; x++)
                    {
                        float amount = Kitchen_Database.Use_IngredientInInventory(dRecipe.Ingredients[x]);
                        if (amount < 0)
                            amount *= -1;
                        TextBlock textBlock = new TextBlock();
                        textBlock.Text = dRecipe.Ingredients[x].Name + " (" + amount.ToString() + " " + dRecipe.Ingredients[x].Amount.UnitsOfMeasurement + ")";
                        textBlock.Background = Brushes.Transparent;
                        textBlock.FontWeight = FontWeights.Bold;
                        stackPanel.Children.Add(textBlock);
                    }
                }
            }
            Border border = new Border();
            border.Background = Brushes.GhostWhite;
            border.BorderBrush = Brushes.Gainsboro;
            border.BorderThickness = new Thickness(1);
            border.Margin = new Thickness(0, 0, 10, 0);

            border.Child = stackPanel;

            Grid.SetColumn(border, 1);
            Grid.SetRow(border, 4);
            TheGrid.Children.Add(border);
        }
    }
}
