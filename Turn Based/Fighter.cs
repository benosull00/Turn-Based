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
            this.health = 100;
            this.damage = 65;
            this.block = 5;
            this.weapons = "Dual Shortswords";
        }

        public override void AttackOpponent(Enemy opponent)
        {
            opponent.RecieveDamageFromPlayer(this.damage);
        }
    }
}
