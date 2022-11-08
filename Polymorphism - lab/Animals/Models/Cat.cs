using System.Text;
using Animals.Models.BaseClasses;

namespace Animals.Models
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"I am {this.Name} and my favourite food is {this.FavouriteFood}");
            sb.Append("MEEOW");

            return sb.ToString();
        }
    }
}