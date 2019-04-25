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
    /// Interaction logic for mainMenu.xaml
    /// </summary>
    public partial class mainMenu : Page
    {
        public event EventHandler PageFinished;
        public int choiceArray;
        public mainMenu()
        {
            InitializeComponent();

        }
        public void toRecipes(object sender, RoutedEventArgs e) {
            choiceArray = 1;
            PageFinished(new object(), new EventArgs());
        }
        public void toIngredients(object sender, RoutedEventArgs e) {
            choiceArray = 2;
            PageFinished(new object(), new EventArgs());
        }
        public void toMealPlanner(object sender, RoutedEventArgs e)
        {
            choiceArray = 3;
            PageFinished(new object(), new EventArgs());
        }
        public void exit(object sender, RoutedEventArgs e) {
            choiceArray = 6;
            PageFinished(new object(), new EventArgs());
        }
        public void toShoppingList(object sender, RoutedEventArgs e) {
            choiceArray = 4;
            PageFinished(new object(), new EventArgs());
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Kitchen_Database.SaveData();
        }
    }
}
