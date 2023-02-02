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
            this.health = GetHealth();
            this.damage = 90;
            this.block = 2;
            this.weapons = "Claws";
        }

        public override void AttackOpponent(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(GetDamage());
        }


        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(75, 95);
            return damage;
        }

        int GetHealth()
        {
            Random enemyHealthRND = new Random();
            int enemyHealth = enemyHealthRND.Next(46, 53);
            return enemyHealth;
        }
    }
}
