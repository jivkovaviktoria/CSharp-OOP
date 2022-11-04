using System;
using System.Globalization;
using Microsoft.VisualBasic.CompilerServices;

namespace BirthdayCelebration.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = DateTime.ParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        
        public string Name { get; }
        public DateTime Birthday { get; }

        public string GetYear() => this.Birthday.Year.ToString();
    }
}