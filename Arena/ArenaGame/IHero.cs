using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public interface IHero
    {
        double Attack(Hero opponent);
        double Defend(double damage);
    }
}
