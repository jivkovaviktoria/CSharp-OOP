namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        //saltwater aquarium
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, 5, price)
        {
        }

        public override void Eat() => this.Size += 2;
    }
}