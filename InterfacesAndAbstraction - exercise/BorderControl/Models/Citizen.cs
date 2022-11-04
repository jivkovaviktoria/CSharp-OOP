using BorderControl.Models.Contracts;

namespace BorderControl.Models
{
    public class Citizen : ICitizen
    {
        public Citizen(string id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
        
        
        public string Name { get; }
        public int Age { get; }
        
        public string Id { get; }
        
        public bool IsValidId(string x)
        {
            if (this.Id.EndsWith(x)) return false;
            return true;
        }

    }
}