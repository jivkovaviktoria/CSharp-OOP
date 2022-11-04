using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Models;
using Raiding.Models.Contracts;

namespace Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IHero> heroes = new List<IHero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();
                
                if(type == nameof(Druid)) heroes.Add(new Druid(name));
                else if(type == nameof(Paladin)) heroes.Add(new Paladin(name));
                else if(type == nameof(Rogue)) heroes.Add(new Rogue(name));
                else if(type == nameof(Warrior)) heroes.Add(new Warrior(name));
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in heroes) Console.WriteLine(hero.CastAbility());

            if(heroes.Select(x => x.Power).Sum() >= bossPower) Console.WriteLine("Victory!");
            else Console.WriteLine("Defeat...");
        }
    }
}