using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Dragon : Enemy
    {
        public Dragon()
        {
            this.name = "Dragon";
            this.health = 175;
            this.damage = 100;
            this.block = 5;
            this.weapons = "Flame Breath";
        }

        public override void AttackOpponent(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(GetDamage());
        }

        public override void FlameBreathVSTank(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(GetDamage() - 2);
        }

        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(90, 125);
            return damage;
        }

    }
}
