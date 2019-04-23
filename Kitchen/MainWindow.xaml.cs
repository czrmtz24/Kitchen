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
        private Kitchen.pages.mainMenu mainMenu;
        private Kitchen.pages.recipes recipes;
        private Kitchen.pages.viewRecipes viewRecipes;
        public MainWindow()
        {
            InitializeComponent();
            CreatePages();
            Main.Navigate(mainMenu);
            
        }
        public void toRecipes()
        {
            Main.Content = new Kitchen.pages.viewRecipes();
        }

        public void CreatePages()
        {
            mainMenu = new pages.mainMenu();
            mainMenu.PageFinished += pageFinished;

            recipes = new pages.recipes();
            recipes.PageFinished += pageFinished;

            viewRecipes = new pages.viewRecipes();
            viewRecipes.PageFinished += pageFinished;
        }
        private void pageFinished(object sender, EventArgs e)
        {

        }
    }
}
