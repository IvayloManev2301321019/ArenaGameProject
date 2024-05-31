using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Weapons
{
    public class Dagger : IWeapon
    {
        public string Name { get; set; }

        public double AttackDamage { get; private set; }

        public double BlockingPower { get; private set; }

        public Dagger(string name)
        {
            Name = name;
            AttackDamage = 30;
            BlockingPower = 1;
        }

        public string SpecialAbility()
        {
            Random random = new Random();
            double chance = random.NextDouble();
            if (chance < 0.25) 
            {
                AttackDamage = 60;
                return $" Critical Hit, doubling attack power";
            }
            else
            {
                AttackDamage = 30;
                return $" Critical Hit, unsuccessfully doubling attack power";
            }
        }
    }
}
