using System;
using System.Collections.Generic;
using BorderControl.Models;
using BorderControl.Models.Contracts;

namespace BorderControl
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string name, id, age;
            IIdentifiable entity;
            var entities = new List<IIdentifiable>();
            
            var input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split();
                name = tokens[0];
                
                if (tokens.Length == 2)
                {
                    id = tokens[1];
                    entity = new Robot(name, id);
                    entities.Add(entity);
                }
                else
                {
                    age = tokens[1];
                    id = tokens[2];

                    entity = new Citizen(id, name, int.Parse(age));
                    entities.Add(entity);
                }
                
                input = Console.ReadLine();
            }

            string fakeIdEnd = Console.ReadLine();
            entities.RemoveAll(x => x.IsValidId(fakeIdEnd));
            foreach(var ent in entities)
                Console.WriteLine(ent.Id);
        }
    }
}