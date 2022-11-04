using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayCelebration.Models;

namespace BirthdayCelebration
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var entities = new List<IBirthable>();
            string name, id, birthday;
            int age;
            
            var input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split();
                var type = tokens[0];

                if (type == "Citizen")
                {
                    name = tokens[1];
                    age = int.Parse(tokens[2]);
                    id = tokens[3];
                    birthday = tokens[4];
                    
                    entities.Add(new Citizen(name, age, id, birthday));
                }
                else if (type == "Pet")
                {
                    name = tokens[1];
                    birthday = tokens[2];
                    
                    entities.Add(new Pet(name, birthday));
                }
                
                input = Console.ReadLine();
            }

            string year = Console.ReadLine();
            foreach(var entity in entities.Where(x => x.Birthday.Year.ToString() == year))
                Console.WriteLine(entity.Birthday.ToString("dd'/'MM'/'yyyy"));
                
        }
    }
}