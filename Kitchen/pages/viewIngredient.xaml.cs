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
    /// Interaction logic for viewIngredient.xaml
    /// </summary>
    public partial class viewIngredient : Page
    {
        public event EventHandler PageFinished;
        public string ingredientName;
        public viewIngredient()
        {
            InitializeComponent();
        }
        public void loadIngredient()
        {
            if (this.ingredientName == "")
            {
                return;
            }
            List<Ingredient> ingredients = Kitchen_Database.Inventory;
            Ingredient ingredient = new Ingredient();
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients.ElementAt(i).Name == ingredientName)
                {
                    ingredient = ingredients.ElementAt(i);
                }

            }
            IngredientName.Text = ingredientName;
            IngredientDescription.Text = ingredient.Description;
            IngredientMeasurement.Text = ingredient.Amount.MeasurementAmount.ToString() + " " + ingredient.Amount.UnitsOfMeasurement;
        }
        public void setText(string ingredientName)
        {
            this.ingredientName = ingredientName;
            System.Console.WriteLine($"Ingredient Loaded in: {this.ingredientName}");
        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            Ingredient ingredient = new Ingredient();
            List<Ingredient> ingredients = Kitchen_Database.Inventory;
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients.ElementAt(i).Name == ingredientName)
                {
                    ingredients.RemoveAt(i);
                    PageFinished(new object(), new EventArgs());
                }
            }
        }
    }
}
