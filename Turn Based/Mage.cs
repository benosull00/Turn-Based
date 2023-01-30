using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Mage : Character
    {
        public Mage()
        {
            this.name = "";
            this.health = 100;
            this.damage = 60;
            this.block = 6;
            this.weapons = "Staff of Fire\nStaff of Ice";
        }

        public override void AttackOpponent(Enemy opponent)
        {
            opponent.RecieveDamageFromPlayer(this.damage);
        }
    }
}
