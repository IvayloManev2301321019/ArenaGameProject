using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Viking : Hero
    {
        public int Berserk { get; private set; } = 0; //Увеличава Damage на Attack по 3, и полученият Damage от Defend по 2
        public Viking(string name, double armor, double strength, IWeapon weapon) : base(name, armor, strength, weapon)
        {
        }

        public override double Attack(Hero opponent)
        {
            double baseDamage = base.Strike();
            if (Berserk == 0)
            {

                double probability = random.NextDouble();
                if (probability < 0.30)
                {
                    Berserk += 2;
                }
                return opponent.Defend(baseDamage);

            }

            else
            {
                Berserk--;
                return opponent.Defend(baseDamage * 3);
            }
        }

        public override double Defend(double damage)
        {
            if (Berserk == 0)
            {
                return base.Defend(damage);
            }

            else
            {
                Berserk--;
                return base.Defend(damage * 2);
            }

        }
    }
}
