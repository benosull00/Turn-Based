using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Fighter : Character
    {
        public Fighter()
        {
            this.name = ""; 
            this.health = 140;
            this.damage = 30;
            this.block = 8;
        }
    }
}
