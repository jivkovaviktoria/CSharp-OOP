using System;
using System.Collections.Generic;
using System.Linq;
using FoodShortage.Models;
using FoodShortage.Models.Contracts;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var entities = new List<IBuyer>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split();
                
                if (tokens.Length == 3)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var group = tokens[2];
                    
                    entities.Add(new Rebel(name, age, group));
                }
                else if (tokens.Length == 4)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var id = tokens[2];
                    var birthday = tokens[3];
                    
                    entities.Add(new Citizen(name, age, id, birthday));
                }
            }

            var cmd = Console.ReadLine();
            while (cmd != "End")
            {
                var entity = entities.Find(x => x.Name == cmd);
                if(entity != null) entity.BuyFood();
                
                cmd = Console.ReadLine();
            }

            Console.WriteLine(entities.Select(x => x.Food).Sum());
        }
    }
}