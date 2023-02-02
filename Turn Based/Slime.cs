using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Slime : Enemy
    {
        public Slime()
        {
            this.name = "Slime";
            this.health = GetHealth();
            this.damage = 85;
            this.block = 3;
            this.weapons = "Toxic Sludge";
        }

        public override void AttackOpponent(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(GetDamage());
        }

        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(65, 90);
            return damage;
        }

        int GetHealth()
        {
            Random enemyHealthRND = new Random();
            int enemyHealth = enemyHealthRND.Next(51, 56);
            return enemyHealth;
        }
    }
}
