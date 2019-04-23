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
    /// Interaction logic for recipes.xaml
    /// </summary>
    public partial class recipes : Page
    {
        LinkedList<Recipe> myRecipes;
        public event EventHandler PageFinished;
        public recipes()
        {
            InitializeComponent();
            myRecipes = new LinkedList<Recipe>();
            loadRecipes();
        }
        public recipes(LinkedList<Recipe> recipes) : this() {
            foreach (Recipe recipe in recipes) {
                myRecipes.AddLast(recipe);
            }
        }
        public void loadRecipes() {
            int count = myRecipes.Count;

            for (int i = 0; i < count; i++)
            {
                TheGrid.RowDefinitions.Add(new RowDefinition());
                Button button = new Button();
                Recipe tempRecipe = myRecipes.ElementAt(i);
                button.Content = tempRecipe.Name;
                Grid.SetRow(button, i+1);
                System.Console.WriteLine(tempRecipe.Name);
            }


        }
    }
}
