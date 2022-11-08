using System.Text;

namespace Animals.Models.BaseClasses
{
    public abstract class Animal
    {
        protected Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }
        
        public string Name { get; set; }
        public string FavouriteFood { get; set; }

        public virtual string ExplainSelf() => "";
    }
}