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


namespace Kitchen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void toIngredients(object sender, RoutedEventArgs e)
        {
        }
        private void toRecipes(object sender, RoutedEventArgs e)
        {
        }

        private void toAddIngredients(object sender, RoutedEventArgs e)
        {
        }

        private void toAddRecipe(object sender, RoutedEventArgs e)
        {
        }

        private void toMealPlan(object sender, RoutedEventArgs e)
        {
        }

        private void toShoppingList(object sender, RoutedEventArgs e)
        {
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
