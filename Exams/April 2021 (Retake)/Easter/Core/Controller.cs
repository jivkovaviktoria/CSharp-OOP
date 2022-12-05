using System;
using System.Linq;
using System.Text;
using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunnies = new BunnyRepository();
        private EggRepository eggs = new EggRepository();

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == nameof(SleepyBunny)) bunny = new SleepyBunny(bunnyName);
            else if (bunnyType == nameof(HappyBunny)) bunny = new HappyBunny(bunnyName);
            else throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);

            this.bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunny = this.bunnies.FindByName(bunnyName);
            if (bunny == null) throw new InvalidOperationException(ExceptionMessages.InexistentBunny);

            var dye = new Dye(power);
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            this.eggs.Add(new Egg(eggName, energyRequired));
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var egg = this.eggs.FindByName(eggName);
            
            var workBunnies = bunnies.Models.OrderByDescending(x => x.Energy).TakeWhile(x => x.Energy >= 50);
            if (!workBunnies.Any()) throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);

            var workshop = new Workshop();
            foreach (var bunny in workBunnies)
            {
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0) this.bunnies.Remove(bunny);
            }

            if (egg.IsDone()) return string.Format(OutputMessages.EggIsDone, eggName);
            else return string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Count(x => x.IsDone())} eggs are done!");
            sb.Append($"Bunnies info:");
            foreach (var bunny in bunnies.Models)
            {
                sb.AppendLine();
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.Append($"Dyes: {bunny.Dyes.Count(x => !x.IsFinished())} not finished");
            }
            return sb.ToString().TrimEnd();
        }
    }
}