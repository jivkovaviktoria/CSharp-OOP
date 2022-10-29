namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        public NuclearWeapon(int destructionLevel)
            : base(15, destructionLevel)
        {
        }
    }
}