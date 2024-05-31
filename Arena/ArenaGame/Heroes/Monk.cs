using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Monk : Hero
    {

        public Monk(string name, double armor, double strenght, IWeapon weapon) : base(name, armor, strenght, weapon)
        {
        }

        public override double Attack(Hero opponent)
        {
            double baseDamage = Strike();
            double realDamage = opponent.Defend(baseDamage);
            double stunProbability = random.NextDouble();
            if (stunProbability < 0.3) //30% шанс за причиняване на StunStatus, прекъсващ атаките на опонента за 2 хода
            {
                opponent.StunStatus = 2;
            }
            return realDamage;
        }

        public override double Defend(double damage)
        {
            double probability = random.NextDouble(); //30% шанс за прескачане на атаката
            if (probability < 0.30)
            {
                return 0;
            }

            else return base.Defend(damage);
        }
    }
}
