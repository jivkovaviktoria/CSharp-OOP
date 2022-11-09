namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        //can only live in freshwater aquarium
        public FreshwaterFish(string name, string species, decimal price) : base(name, species, 5, price)
        {
        }

        public override void Eat() => this.Size += 3;
    }
}