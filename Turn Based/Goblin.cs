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
            this.health = GetHealth();
            this.damage = 60;
            this.block = 4;
            this.weapons = "Shortsword";
        }

        public override void AttackOpponent(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(GetDamage());
        }
        public override void FlameBreathVSTank(Character opponent) { }

        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(50, 75);
            return damage;
        }
        int GetHealth()
        {
            Random enemyHealthRND = new Random();
            int enemyHealth = enemyHealthRND.Next(65, 70);
            return enemyHealth;
        }
    }
}
