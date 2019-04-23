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
        public LinkedList<Recipe> recipeList;
        public MainWindow()
        {
            InitializeComponent();
            recipeList = new LinkedList<Recipe>();
            loadRecipes();
            CreatePages();
            Main.Navigate(mainMenu);
            
        }
        public void toRecipes()
        {
            Main.Content = new Kitchen.pages.viewRecipes();
        }

        private void CreatePages()
        {
            mainMenu = new pages.mainMenu();
            mainMenu.PageFinished += pageFinished;

            recipes = new pages.recipes(recipeList);
            recipes.PageFinished += pageFinished;

            viewRecipes = new pages.viewRecipes();
            viewRecipes.PageFinished += pageFinished;
        }
        private void pageFinished(object sender, EventArgs e)
        {
            if (Main.Content == mainMenu) {
                switch (mainMenu.choiceArray) {
                    case 1:
                        Main.Navigate(recipes);
                        break;
                    case 2:
                        //Main.Navigate(inventory);
                        break;
                    case 3:
                        //Main.Navigate(shoppingList
                        break;
                    case 4:
                        this.Close();
                        break;
                }
            }
        }
        public void loadRecipes() {
            string name = "Lasagna";
            string description = "The best lasagna in WSU";
            LinkedList<string> steps = new LinkedList<string>();
            LinkedList<Ingredient> ingredients = new LinkedList<Ingredient>();
            Ingredient pepper = new Ingredient("pepper", "pepper", "1 tablespoon");
            steps.AddLast("Turn oven to 350 degrees");
            steps.AddLast("Put frozen lasagna in the oven");
            steps.AddLast("Wait 35 minutes");

            ingredients.AddLast(pepper);

            Recipe lasagna = new Recipe(name, description, ingredients, steps);
            recipeList.AddLast(lasagna);
        }
    }
}
