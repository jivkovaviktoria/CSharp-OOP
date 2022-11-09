using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine().Split()[1];

                string[] doughData = Console.ReadLine().Split();

                string flour = doughData[1];
                string baking = doughData[2];
                double weight = double.Parse(doughData[3]);

                Dough dough = new Dough(flour, baking, weight);
                Pizza pizza = new Pizza(name, dough);

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string topType = input.Split()[1];
                    double topGrams = double.Parse(input.Split()[2]);
                    Topping topping = new Topping(topType, topGrams);
                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}