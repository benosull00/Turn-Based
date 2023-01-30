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
            this.health = 50;
            this.damage = 70;
            this.block = 2;
            this.weapons = "Claws";
        }

        public override void AttackOpponent(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(this.damage);
        }

    }
}
