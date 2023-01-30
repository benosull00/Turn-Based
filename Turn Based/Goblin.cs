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
            this.health = 70;
            this.damage = 20;
            this.block = 3;
            this.weapons = "Shortsword";
        }

        public override void AttackOpponent(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(this.damage);
        }
    }
}
