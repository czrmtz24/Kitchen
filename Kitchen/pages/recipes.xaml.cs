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
using System.Windows.Controls.Primitives;
using static Kitchen.Globals;
namespace Kitchen.pages
{
    /// <summary>
    /// Interaction logic for recipes.xaml
    /// </summary>
    public partial class recipes : Page
    {
        LinkedList<Recipe> myRecipes;
        public event EventHandler PageFinished;
        public int choiceArray;
        public string recipeToView;
        public recipes()
        {
            InitializeComponent();
            loadRecipes();
        }

        public void loadRecipes() {
            int count = userData.MyRecipes.Count;
            for (int i = 0; i < count; i++)
            {
                Button button = new Button();
                Recipe tempRecipe = userData.myRecipes.ElementAt(i);
                button.Content = tempRecipe.Name;
                Grid.SetRow(button, i+4);
                Grid.SetColumn(button, 1);
                System.Console.WriteLine($"Adding recipe to recipe view: {tempRecipe.Name}");
                button.Click += new RoutedEventHandler(toViewRecipe);
                TheGrid.Children.Add(button);
            }
        }
        public void toAddRecipe(object sender, RoutedEventArgs e)
        {
            choiceArray = 2;
            PageFinished(new object(), new EventArgs());
        }
        public void getNewRecipe(object sender, RoutedEventArgs e) {
            choiceArray = 2;
        }
        public void deleteRecipe(object sender, RoutedEventArgs e)
        {
            if (userData.MyRecipes.Count == 0)
            {
                return;
            }
            choiceArray = 1;
            userData.myRecipes.RemoveLast();
            PageFinished(new object(), new EventArgs());
        }
        public void toViewRecipe(object sender, RoutedEventArgs e)
        {
            choiceArray = 3;
            Button tempButton = sender as Button;
            recipeToView = tempButton.Content.ToString();
            //System.Console.WriteLine(recipeName);
            PageFinished(new object(), new EventArgs());
        }
    }
}
