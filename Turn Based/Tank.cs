using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Tank : Character
    {
        public Tank()
        {
            this.name = "";
            this.health = 200;
            this.damage = 20;
            this.block = 10;
            this.weapons = "Longsword\nShield";
        }

    }
}
