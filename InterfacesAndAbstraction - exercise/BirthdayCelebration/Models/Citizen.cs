using System;
using System.Globalization;

namespace BirthdayCelebration.Models
{
    public class Citizen : IBirthable
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = DateTime.ParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public DateTime Birthday { get; }

        public string GetYear() => this.Birthday.Year.ToString();
    }
}