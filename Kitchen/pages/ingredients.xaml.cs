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
using Kitchen.Meal;
using Kitchen.Inventory;
using static Kitchen.Kitchen_Database;
namespace Kitchen.pages
{
    /// <summary>
    /// Interaction logic for ingredients.xaml
    /// </summary>
    public partial class ingredients : Page
    {
        public int choiceArray;
        public string ingredientToView;
        public EventHandler PageFinished;
        public ingredients()
        {
            InitializeComponent();
            loadIngredients();
        }
        public void loadIngredients()
        {
            List<Ingredient> ingredientList = Kitchen_Database.Inventory;

            for (int i = 0; i < ingredientList.Count; i++)
            {
                Button button = new Button();
                Ingredient tempIngredient = ingredientList[i];

                button.Content = tempIngredient.Name;
                Grid.SetRow(button, i + 4);
                Grid.SetColumn(button, 1);
                System.Console.WriteLine($"Adding ingredient to ingredient view: {tempIngredient.Name}");
                button.Click += new RoutedEventHandler(toViewIngredients);
                TheGrid.Children.Add(button);
            }
        }
        public void toAddIngredient(object sender, RoutedEventArgs e)
        {
            choiceArray = 2;
            PageFinished(new object(), new EventArgs());
        }
        public void toViewIngredients(object sender, RoutedEventArgs e)
        {
            choiceArray = 3;
            Button tempButton = sender as Button;
            ingredientToView = tempButton.Content.ToString();
            PageFinished(new object(), new EventArgs());
        }
    }
}
