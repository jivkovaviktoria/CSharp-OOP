using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Models;
using MilitaryElite.Models.Contracts.Missions;
using MilitaryElite.Models.Contracts.Repairs;
using MilitaryElite.Models.Soldiers;
using MilitaryElite.Models.Soldiers.PrivateSoldiers;
using MilitaryElite.Models.Soldiers.PrivateSoldiers.SpecialisedSoldiers;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var privates = new List<Soldier>();

            string input;
            Soldier soldier = null;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var type = tokens[0];
                string id = tokens[1], firstName = tokens[2], lastName = tokens[3];

                if (type == nameof(Private))
                {
                    var salary = decimal.Parse(tokens[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                    privates.Add(soldier);
                }
                else if (type == nameof(Spy))
                {
                    var codeNumber = int.Parse(tokens[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    var salary = decimal.Parse(tokens[4]);
                    var privatesData = tokens.Skip(5).ToArray();

                    List<Soldier> soldierPrivates = new List<Soldier>();
                    foreach (var item in privatesData)
                    {
                        if (privates.Any(x => x.Id == item))
                            soldierPrivates.Add(privates.Find(x => x.Id == item));
                    }

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, soldierPrivates);
                }
                else if (type == nameof(Engineer))
                {
                    var salary = decimal.Parse(tokens[4]);
                    var corps = tokens[5];
                    var repairsData = tokens.Skip(6).ToArray();

                    var repairs = new List<Repair>();

                    for (int i = 0; i < repairsData.Length; i += 2)
                    {
                        var name = repairsData[i];
                        var hours = int.Parse(repairsData[i + 1]);

                        repairs.Add(new Repair(name, hours));
                    }

                    try
                    {
                        soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
                else if (type == nameof(Commando))
                {
                    var salary = decimal.Parse(tokens[4]);
                    var corps = tokens[5];
                    var missionsData = tokens.Skip(6).ToArray();

                    try
                    {
                        soldier = new Commando(id, firstName, lastName, salary, corps, missionsData);
                    }
                    catch (Exception e){continue;}
                }

                Console.WriteLine(soldier.ToString());
            }
        }
    }
}