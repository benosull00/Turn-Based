using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Fighter : Character
    {
        public Fighter()
        {
            this.name = ""; 
            this.health = 105;
            this.damage = 85;
            this.block = 6;
            this.weapons = "Dual Shortswords";
            this.itemCount = 2;
            this.itemNames = "Health potion";
            this.specialItemCount = 5;
            this.specialMove = "Double Slash";
        }

        public override void AttackOpponent(Enemy opponent)
        {
            opponent.RecieveDamageFromPlayer(GetDamage());
        }

        public override void DoubleSlashOpponent(Enemy opponent)
        {
            opponent.RecieveDamageFromPlayer(GetDamage() * 2);
        }

        public override void FireAttack(Enemy opponent) { }

        public override void IceAttack(Enemy opponent) { }

        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(75, 105);
            return damage;
        }
    }
}
