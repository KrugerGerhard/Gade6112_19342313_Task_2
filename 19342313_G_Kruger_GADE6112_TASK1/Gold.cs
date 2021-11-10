using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    [System.Serializable()]
    class Gold : Item
    {
        private int gold;
        private Random random = new Random();

        public Gold (int x , int y) : base ( x , y )
        {
            gold = random.Next(1, 6);
            tiletype0 = Tile.TileType.Gold;

        }

        public int GetGold()
        {
            return gold;
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }

    }
}
