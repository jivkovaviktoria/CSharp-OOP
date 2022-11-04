namespace BorderControl.Models.Contracts
{
    public interface IIdentifiable
    {
        public string Id { get; }

        public bool IsValidId(string x);
    }
}