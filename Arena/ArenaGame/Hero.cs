using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public abstract class Hero : IHero
    {
        protected Random random = new Random();
        public string Name { get; private set; }
        public double Health { get; private set; }
        public double Armor { get; private set; }
        public double Strength { get; private set; }
        public IWeapon Weapon { get; private set; }
        public int StunStatus { get; set; } = 0;
        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public Hero(string name, double armor, double strenght, IWeapon weapon)
        {
            Health = 100;

            Name = name;
            Armor = armor;
            Strength = strenght;
            Weapon = weapon;
        }

        public virtual double Strike()
        {
            if (StunStatus > 0)
            {
                StunStatus--;
                return 0;
            }
            else
            {
                Weapon.SpecialAbility();
                double totalDamage = Strength + Weapon.AttackDamage;
                double coef = random.Next(80, 120 + 1);
                double realDamage = totalDamage * (coef / 100);
                return realDamage;
            }
        }
        // returns actual damage
        public virtual double Attack(Hero opponent)
        {
            double baseDamage = Strike();
            return opponent.Defend(baseDamage);
        }

        public virtual double Defend(double damage)
        {
            double coef = random.Next(80, 120 + 1);
            double defendPower = (Armor + Weapon.BlockingPower) * (coef / 100);
            double realDamage = damage - defendPower;
            if (realDamage < 0)
                realDamage = 0;
            Health -= realDamage;
            return realDamage;
        }

        public override string ToString()
        {
            return $"{Name} with health {Math.Round(Health,2)}";
        }
    }
}
