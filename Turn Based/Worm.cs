using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Worm : Enemy
    {
        public Worm()
        {
            this.name = "Worm";
            this.health = GetHealth();
            this.damage = 60;
            this.block = 3;
            this.weapons = "Bite";
        }

        public override void AttackOpponent(Character opponent)
        {
            opponent.RecieveDamageFromEnemy(GetDamage());
        }
        public override void FlameBreathVSTank(Character opponent) { }


        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(45, 80);
            return damage;
        }

        int GetHealth()
        {
            Random enemyHealthRND = new Random();
            int enemyHealth = enemyHealthRND.Next(35, 60);
            return enemyHealth;
        }
    }
}
