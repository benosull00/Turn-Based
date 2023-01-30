using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Goblin : Enemy
    {
        public Goblin()
        {
            this.name = "Goblin";
            this.health = 120;
            this.damage = 20;
            this.block = 8;
            this.weapons = "Shortsword";
        }
    }
}
