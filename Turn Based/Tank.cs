﻿using System;
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
            this.health = 100;
            this.damage = 55;
            this.block = 7;
            this.weapons = "Longsword\nShield";
        }

        public override void AttackOpponent(Enemy opponent)
        {
            opponent.RecieveDamageFromPlayer(this.damage);
        }
    }
}
