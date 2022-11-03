namespace ExplicitInterfaces.Models.Contracts
{
    public interface IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public void GetName();
    }
}