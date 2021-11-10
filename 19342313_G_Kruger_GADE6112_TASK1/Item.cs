using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    [System.Serializable()]
    abstract class Item : Tile
    {
        protected Item(int x, int y) : base(x, y)
        {

        }

        public abstract string ToString();
    }
}
