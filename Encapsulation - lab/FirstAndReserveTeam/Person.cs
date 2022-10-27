using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    using ErrorMessages;
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value.Length < 3) throw new ArgumentException(ErrorMessages.InvalidFirstName);
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value.Length < 3) throw new ArgumentException(ErrorMessages.InvalidLastName);
                else this.lastName = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            private set
            {
                if (value <= 0) throw new ArgumentException(ErrorMessages.InvalidAge);
                else this.age = value;
            }
        }
        public decimal Salary
        {
            get { return this.salary; }
            private set
            {
                if (value < 650) throw new ArgumentException(ErrorMessages.InvalidSalary);
                else this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percent)
        {
            var bonus = this.Salary * percent / 100;

            if (this.Age > 30) this.Salary += bonus;
            else this.Salary += bonus / 2;
        }

        public override string ToString() => $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
    }
}
