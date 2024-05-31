using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Assassin : Hero
    {
        public Assassin(string name, double armor, double strenght, IWeapon weapon) : 
            base(name, armor, strenght, weapon)
        {
        }

        public override double Attack(Hero opponent)
        {
            double baseDamage = Strike();
            double probability = random.NextDouble();
            if (probability < 0.10)
            {
                baseDamage *= 3;
            }

            return opponent.Defend(baseDamage);
        }
    }
}
