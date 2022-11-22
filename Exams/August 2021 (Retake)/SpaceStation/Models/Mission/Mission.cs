using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var x in astronauts)
            {
                while (x.CanBreath)
                {
                    var item = planet.Items.Last();
                    x.Breath();
                    
                    planet.Items.Remove(item);
                    x.Bag.Items.Add(item);
                }
            }
        }
    }
}