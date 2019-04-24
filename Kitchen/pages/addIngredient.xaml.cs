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
using Kitchen.Inventory;
using static Kitchen.Kitchen_Database;
namespace Kitchen.pages
{
    /// <summary>
    /// Interaction logic for addIngredient.xaml
    /// </summary>
    public partial class addIngredient : Page
    {
        //Ingredient m_ingredient;
        public event EventHandler PageFinished;
        public addIngredient()
        {
            InitializeComponent();
        }
        public void submitIngredient(object sender, RoutedEventArgs e)
        {
            if (IngredientNameToAdd.Text == "")
            {
                System.Console.WriteLine("submit failed");
                return;
            }
            string name = IngredientNameToAdd.Text;
            string description = IngredientDescriptionToAdd.Text;
            string quantity = IngredientQuantityToAdd.Text;
            string measurementType = IngredientTypeToAdd.Text;

            Measurement newMeasurement = new Measurement(int.Parse(quantity),
                                                            measurementType);
            Ingredient newIngredient = new Ingredient(newMeasurement, description, name);

            Kitchen_Database.Add_IngredientToInventory(newIngredient);

            System.Console.WriteLine("Submit suceeded");
            PageFinished(new object(), new EventArgs());
        }
    }
}
