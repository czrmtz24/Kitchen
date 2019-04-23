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
    /// Interaction logic for recipes.xaml
    /// </summary>
    public partial class recipes : Page
    {
        LinkedList<Recipe> myRecipes;
        public event EventHandler PageFinished;
        public recipes()
        {
            InitializeComponent();
            loadRecipes();
        }

        public void loadRecipes() {
            int count = userData.MyRecipes.Count;

            for (int i = 0; i < count; i++)
            {
                RowDefinition r1 = new RowDefinition();
                r1.Height = GridLength.Auto;
                TheGrid.RowDefinitions.Add(r1);
                Button button = new Button();
                Recipe tempRecipe = userData.myRecipes.ElementAt(i);
                button.Content = tempRecipe.Name;
                Grid.SetRow(button, i+1);
                Grid.SetColumn(button, 1);
                
                System.Console.WriteLine(tempRecipe.Name);
                TheGrid.Children.Add(button);
            }


        }
    }
}
