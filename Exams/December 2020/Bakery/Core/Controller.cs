namespace Bakery.Core
{
    using Bakery.Core.Contracts;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Messages;

    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods = new List<IBakedFood>();
        private readonly List<IDrink> drinks = new List<IDrink>();
        private readonly List<ITable> tables = new List<ITable>();

        private decimal TotalRestaurantIncome;
        
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == nameof(Tea)) drink = new Tea(name, portion, brand);
            else if (type == nameof(Water)) drink = new Water(name, portion, brand);
            
            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == nameof(Bread)) food = new Bread(name, price);
            else if (type == nameof(Cake)) food = new Cake(name, price);
            
            bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, food.Name, food.GetType().Name);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == nameof(InsideTable)) table = new InsideTable(tableNumber, capacity);
            else if (type == nameof(OutsideTable)) table = new OutsideTable(tableNumber, capacity);
            
            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, table.TableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var notReservedTables = tables.Where(t => t.IsReserved == false).ToList();
            
            StringBuilder sb = new StringBuilder();
            foreach (var table in notReservedTables) sb.AppendLine(table.GetFreeTableInfo());
            
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome() => string.Format(OutputMessages.TotalIncome, TotalRestaurantIncome);
        

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            
            if (table == null)
             throw new ArgumentException(string.Format(OutputMessages.WrongTableNumber, tableNumber));
            
            var totalTableSum = table.GetBill();

            this.TotalRestaurantIncome += totalTableSum;

            table.Clear();

            var sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.Append($"Bill: {totalTableSum:f2}");

            return sb.ToString();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            

            if (drink == null)
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            
            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood bakedFood = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            

            if (bakedFood == null)
                return string.Format(OutputMessages.NonExistentFood, foodName);
            
            table.OrderFood(bakedFood);

            return string.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, bakedFood.Name);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            else
            {
                table.Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }
    }
}