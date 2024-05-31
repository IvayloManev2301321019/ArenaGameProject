using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    internal class Axe : IWeapon
    {
        public string Name { get; set; }

        public double AttackDamage { get; private set; }

        public double BlockingPower { get; private set; }

        public Axe(string name)
        {
            Name = name;
            AttackDamage = 60;
            BlockingPower = 1;
        }

        public string SpecialAbility()
        {
            Random random = new Random();
            double chance = random.NextDouble();
            if (chance < 0.5)
            {
                AttackDamage = 0;
                return $" Strong attack, missing the target";
            }
            else
            {
                AttackDamage = 60;
                return $" Strong attack, hitting the target";
            }
        }
    }
}
