using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Skeleton : Enemy
    {
        public Skeleton()
        {
            this.name = "Skeleton";
            this.health = GetHealth();
            this.damage = 60;
            this.block = 3;
            this.weapons = "Dagger";
        }

        public override void AttackOpponent(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(GetDamage());
        }

        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(55, 70);
            return damage;
        }
        int GetHealth()
        {
            Random enemyHealthRND = new Random();
            int enemyHealth = enemyHealthRND.Next(60, 70);
            return enemyHealth;
        }
    }
}
