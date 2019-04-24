using Kitchen.Inventory;
using Kitchen.Meal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Storage
{
    public static class Storage
    {
        public static List<Ingredient> Load_Inventory()
        {
            List<Ingredient> ingredientList = new List<Ingredient>();

            using (var stream = new FileStream("KitchenData.csv", FileMode.OpenOrCreate))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    string sReadInLine;

                    do
                    {
                        sReadInLine = streamReader.ReadLine();

                        if(sReadInLine == "I")
                        {
                            //Read in next line and parse
                            sReadInLine = streamReader.ReadLine();
                            string[] parsedLine = sReadInLine.Split(',');

                            Measurement newMeasurement = new Measurement(float.Parse(parsedLine[2]), parsedLine[3]);
                            Ingredient newIngredient = new Ingredient(newMeasurement, parsedLine[1], parsedLine[0]);

                            ingredientList.Add(newIngredient);
                        }
                        
                    } while ((sReadInLine != "STOP") && (sReadInLine != null));
                }
            }

            return ingredientList;
        }

        public static List<Recipe> Load_Recipes()
        {
            List<Recipe> recipeList = new List<Recipe>();

            using (var stream = new FileStream("KitchenData.csv", FileMode.OpenOrCreate))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    string sReadInLine;

                    do
                    {
                        sReadInLine = streamReader.ReadLine();

                        if (sReadInLine == "R")
                        {
                            //Read in next line and parse
                            sReadInLine = streamReader.ReadLine();
                            string[] parsedLine = sReadInLine.Split(',');

                            Recipe newRecipe = new Recipe();
                            newRecipe.Name = parsedLine[0];
                            newRecipe.Description = parsedLine[1];

                            //Read in next line for steps
                            sReadInLine = streamReader.ReadLine();
                            parsedLine = sReadInLine.Split(',');

                            foreach (string s in parsedLine)
                            {
                                if(s != "")
                                    newRecipe.Add_Step(s);
                            }

                            sReadInLine = streamReader.ReadLine();
                            parsedLine = sReadInLine.Split(',');

                            //Read in ingredients
                            while (sReadInLine != "Z")
                            {
                                Measurement newMeasurement = new Measurement(float.Parse(parsedLine[2]), parsedLine[3]);
                                Ingredient newIngredient = new Ingredient(newMeasurement, parsedLine[1], parsedLine[0]);

                                newRecipe.Add_Ingredient(newIngredient);

                                sReadInLine = streamReader.ReadLine();
                                parsedLine = sReadInLine.Split(',');

                            }

                            //Add new recipe to the list
                            recipeList.Add(newRecipe);
                        }

                    } while ((sReadInLine != "STOP") && (sReadInLine != null));
                }
            }

            return recipeList;
        }

        public static void Store_Inventory(List<Ingredient> ingredientList)
        {
            using (var stream = new FileStream("KitchenData.csv", FileMode.OpenOrCreate))
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    foreach (Ingredient i in ingredientList)
                    {
                        streamWriter.WriteLine("I");
                        streamWriter.WriteLine($"{i.Name},{i.Description},{i.Amount.MeasurementAmount},{i.Amount.UnitsOfMeasurement}");
                        streamWriter.WriteLine("Z");
                    }
                }
            }
        }

        public static void Store_Recipes(List<Recipe> recipeList)
        {
            using (var stream = new FileStream("KitchenData.csv", FileMode.OpenOrCreate))
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    foreach (Recipe r in recipeList)
                    {
                        streamWriter.WriteLine("R");
                        streamWriter.WriteLine($"{r.Name},{r.Description}");

                        foreach (string s in r.Steps)
                            streamWriter.Write($"{s},");
                        streamWriter.WriteLine("");

                        foreach (Ingredient i in r.Ingredients)
                            streamWriter.WriteLine($"{i.Name},{i.Description},{i.Amount.MeasurementAmount},{i.Amount.UnitsOfMeasurement}");

                        streamWriter.WriteLine("Z");
                    }

                    streamWriter.WriteLine("STOP");
                }
            }
        }
    }
}
