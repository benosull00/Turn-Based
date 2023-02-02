using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Tank : Character
    {
        public Tank()
        {
            this.name = "";
            this.health = 115;
            this.damage = 95;
            this.block = 8;
            this.weapons = "Longsword\nShield";
            this.itemCount = 3;
            this.itemNames = "Health potion";
            this.specialMove = "Shield Bash";
            this.specialItemCount = 5;
        }

        public override void AttackOpponent(Enemy opponent)
        {
            opponent.RecieveDamageFromPlayer(GetDamage());
        }


        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(80, 105);
            return damage;
        }
        public override void DoubleSlashOpponent(Enemy opponent)
        { }

        public override void FireAttack(Enemy opponent) { }

        public override void IceAttack(Enemy opponent) { }
    }
}
