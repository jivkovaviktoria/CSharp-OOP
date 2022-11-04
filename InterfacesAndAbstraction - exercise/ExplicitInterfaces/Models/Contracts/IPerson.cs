namespace ExplicitInterfaces.Models.Contracts
{
    public interface IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void GetName();
    }
}