using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    [System.Serializable()]
    abstract class Enemy : Character
    {
        protected Random random = new Random();

        public Enemy(int x, int y, int maxhp, int damage, char symbol) : base (x , y, maxhp, damage, symbol)
        {

        }

        public override string ToString()
        {
            return this.GetType().Name + " at " + this.X + this.Y + this.damage;
        }
    }
}
