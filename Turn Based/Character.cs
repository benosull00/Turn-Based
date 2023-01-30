using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    public abstract class Character
    {
        public string name;
        public int health = 1;
        public int damage = 1;
        public int block = 1;
        public string weapons;

        public void RecieveDamageFromEnemy(int incomingDamage)
        {
            this.health -= (incomingDamage / block);
        }

        public abstract void AttackOpponent(Enemy opponent);
    }



}
