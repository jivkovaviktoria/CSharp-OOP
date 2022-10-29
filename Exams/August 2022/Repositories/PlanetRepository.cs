namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Planets.Contracts;

    public class PlanetRepository : BaseRepository<IPlanet>
    {
        protected override string GetName(IPlanet item) => item.Name;
    }
}