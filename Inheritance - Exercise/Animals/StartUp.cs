using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            var cmd = Console.ReadLine();
            while(cmd != "Beast!")
            {
                var info = Console.ReadLine().Split();

                string name = info[0], gender = info[2];
                int age = int.Parse(info[1]);


                if (cmd == "Cat")
                {
                    var animal = new Cat(name, age, gender);
                    animals.Add(animal);
                }
                else if(cmd == "Dog")
                {
                    var animal = new Dog(name, age, gender);
                    animals.Add(animal);
                }
                else if(cmd == "Frog")
                {
                    var animal = new Frog(name, age, gender);
                    animals.Add(animal);
                }
                else if(cmd == "Kitten")
                {
                    var animal = new Kitten(name, age);
                    animals.Add(animal);
                }
                else if(cmd == "Tomcat")
                {
                    var animal = new Tomcat(name, age);
                    animals.Add(animal);
                }

                cmd = Console.ReadLine();
            }

            foreach(var animal in animals)
                Console.WriteLine(animal.ToString());
        }
    }
}
