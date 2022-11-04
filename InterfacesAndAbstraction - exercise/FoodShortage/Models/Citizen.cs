using System;
using System.Globalization;
using FoodShortage.Models.Contracts;

namespace FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = DateTime.ParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.Food = 0;
        }
        
        public string Name { get; set; }
        public int Age { get; }
        public string Id { get; }
        public DateTime Birthday { get; }
        public int Food { get; set; }
        
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}