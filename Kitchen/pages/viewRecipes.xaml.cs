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
            TextBlock recipeNameTextBlock = new TextBlock();
            recipeNameTextBlock.Text = recipeName;
            Grid.SetRow(recipeNameTextBlock, 3);
            Grid.SetColumn(recipeNameTextBlock, 2);
            recipeNameTextBlock.FontWeight = FontWeights.Bold;
            recipeNameTextBlock.Background = Brushes.Transparent;
            recipeNameTextBlock.Margin = new Thickness(0, 0, 10, 10);

            TheGrid.Children.Add(recipeNameTextBlock);
           
        }
        public void setText(string recipeName) {
            this.recipeName = recipeName;
            System.Console.WriteLine($"Recipe Loaded in: {this.recipeName}");
        }
    }
}
