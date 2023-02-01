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
            this.health = 100;
            this.damage = GetDamage();
            this.block = 4;
            this.weapons = "Staff of Fire\nStaff of Ice";
            this.itemCount = 2;
            this.itemNames = "Health potion";

        }

        public override void AttackOpponent(Enemy opponent)
        { 
            opponent.RecieveDamageFromPlayer(GetDamage());   
        }

        int GetDamage()
        {
            Random mageDamageRND_r = new Random();
            int damage = mageDamageRND_r.Next(65, 90);
            return damage;
        }
    }
}

