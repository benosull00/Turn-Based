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
        public int itemCount;
        public string itemNames;
        public string specialMove;
        public int specialItemCount;

        public void RecieveDamageFromEnemy(int incomingDamage)
        {
            this.health -= (incomingDamage / block);
            Console.WriteLine($"\nYou take {incomingDamage / block} damage!");
        }

        public abstract void AttackOpponent(Enemy opponent);

        public abstract void DoubleSlashOpponent(Enemy opponent);

        public abstract void FireAttack(Enemy opponent);

        public abstract void IceAttack(Enemy opponent);


    }



}
