using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class BanKiMoon : Enemy
    {
        public BanKiMoon()
        {
            this.name = "Former Sectretary-General of the United Nations Ban Ki-moon";
            this.health = 10;
            this.damage = 1;
            this.block = 1;
            this.weapons = "Fists";
        }

        public override void AttackOpponent(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(this.damage);
        }
    }
}
