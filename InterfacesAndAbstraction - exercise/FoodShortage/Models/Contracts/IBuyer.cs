namespace FoodShortage.Models.Contracts
{
    public interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public void BuyFood();
    }
}