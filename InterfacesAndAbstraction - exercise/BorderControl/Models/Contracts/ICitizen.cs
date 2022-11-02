namespace BorderControl.Models.Contracts
{
    public interface ICitizen : IIdentifiable
    {
        public string Name { get; }
        public int Age { get; }
    }
}