namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        public Claymore(string name, int durability)
            : base(name, durability)
        {
        }

        public override int DoDamage() => 20;
    }
}