using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based
{
    public abstract class Enemy
    {
        public string name;
        public float health = 1; 
        public int damage = 1;
        public int block = 1;
        public string weapons;

        public void RecieveDamageFromPlayer(int incomingDamage)
        {
            this.health -= (incomingDamage / block);
            Console.WriteLine($"\nYou dealt {incomingDamage / block} damage!");
        }

        public abstract void AttackOpponent(Character opponent);

        public abstract void FlameBreathVSTank(Character opponent);

    }

}


