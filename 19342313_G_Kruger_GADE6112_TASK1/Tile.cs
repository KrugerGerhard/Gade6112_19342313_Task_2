using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    [System.Serializable()]
    public abstract class Tile
    {
        protected int x;
        protected int y;

        protected Tile(int Valuex, int Valuey) // Setting initial x & y Tile values.
        {
            X = Valuex;
            Y = Valuey;
        }

        public int X { get; set; } // Setting X integer Coordinates 
        public int Y { get; set; } // Setting Y Integer Coordinates 


        public enum TileType // Enum for different Tile Types 
        {
            Hero,
            Enemy,
            Goblin,
            Weapon,
            Gold,
            Mage,
        }

        public TileType tiletype0 { get; set; }
    }
}
