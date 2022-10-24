using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {

        }

        public override string ProduceSound() => "Meow meow";
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().TrimEnd();
        }
    }
}
