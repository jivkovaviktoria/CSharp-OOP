namespace BorderControl.Models.Contracts
{
    public interface IRobot : IIdentifiable
    {
        public string Model { get; }
    }
}