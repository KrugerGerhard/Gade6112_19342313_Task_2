using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    [System.Serializable()]
    class Goblin : Enemy
    {
        public Goblin(int x, int y) : base( x, y, 10, 1, 'G')
        {
            tiletype0 = TileType.Goblin;
        }
        EnumMovement GoblinMovement;

        public override EnumMovement ReturnMove(EnumMovement move)
        {
            int randomnum0 = random.Next(0, 4);

            if (randomnum0 == 0)
            {
                GoblinMovement = EnumMovement.Up;
            }
            else if (randomnum0 == 1)
            {
                GoblinMovement = EnumMovement.Down;
            }
            else if (randomnum0 == 2)
            {
                GoblinMovement = EnumMovement.Left;
            }
            else if (randomnum0 == 3)
            {
                GoblinMovement = EnumMovement.Right;
            }
            else if (randomnum0 == 4)
            {
                GoblinMovement = EnumMovement.NoMovement;
            }

            return GoblinMovement;
        }
    }
}
