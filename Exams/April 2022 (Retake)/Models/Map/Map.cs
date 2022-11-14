namespace Heroes.Models.Map
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Heroes;

    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var barbarians = players.Where(x => x.GetType().Name == nameof(Barbarian)).ToList();
            var knights = players.Where(x => x.GetType().Name == nameof(Knight)).ToList();

            bool isAllDeadBarbs = false, isAllDeadKnights = false, barbsTurn = false;
            while (!isAllDeadBarbs && !isAllDeadKnights)
            {
                if (barbsTurn)
                {
                    foreach (var barb in barbarians)
                    {
                        if (barb.IsAlive)
                        {
                            foreach (var knight in knights)
                                knight.TakeDamage(barb.Weapon.Durability);
                        }
                    }
                }
                else
                {
                    foreach (var knight in knights)
                    {
                        if (knight.IsAlive)
                        {
                            foreach (var barb in barbarians)
                                barb.TakeDamage(knight.Weapon.Durability);
                        }
                    }
                }

                if (knights.Count(x => x.IsAlive) == 0) isAllDeadKnights = true;
                else if (barbarians.Count(x => x.IsAlive) == 0) isAllDeadBarbs = true;

                barbsTurn = !barbsTurn;
            }

            if (isAllDeadBarbs) return $"The knights took {knights.Count(x => !x.IsAlive)} casualties but won the battle.";
            else return $"The barbarians took {barbarians.Count(x => !x.IsAlive)} casualties but won the battle.";
        }
    }
}