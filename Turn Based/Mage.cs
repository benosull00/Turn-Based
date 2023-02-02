using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    internal class Mage : Character
    {
        public Mage()
        {


            this.name = "";
            this.health = 95;
            this.damage = 110;
            this.block = 4;
            this.weapons = "Staff of Fire\nStaff of Ice";
            this.itemCount = 2;
            this.itemNames = "Health potion";
            this.specialItemCount = 7;
            this.specialMove = "Staff Spell";

        }

        public override void AttackOpponent(Enemy opponent)
        { 
            opponent.RecieveDamageFromPlayer(GetDamage());   
        }


        public override void FireAttack(Enemy opponent)
        {
            opponent.RecieveDamageFromPlayer(GetDamage() * 2);
        }


        public override void IceAttack(Enemy opponent)
        {
            opponent.RecieveDamageFromPlayer(GetDamage() * 2);
        }

        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(100, 115);
            return damage;
        }

        public override void DoubleSlashOpponent(Enemy opponent)
        { }
    }
}

