using System.Linq;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (egg.IsDone() == false && bunny.Dyes.Any(x => x.IsFinished() == false) && bunny.Energy > 0)
            {
                var dye = bunny.Dyes.FirstOrDefault(x => x.IsFinished() == false);

                dye.Use();
                egg.GetColored();
                bunny.Work();
            }
        }
    }
}