using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Wolf : Enemy
    {
        public Wolf()
        {
            this.name = "Wolf";
            this.health = 90;
            this.damage = 12;
            this.block = 4;
            this.weapons = "Claws";
        }
    }
}
