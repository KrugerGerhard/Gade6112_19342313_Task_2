using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    class Mage : Enemy
    {
        public Mage(int x, int y) : base(x, y, 5, 5, 'M')
        {
            tiletype0 = TileType.Mage;
        }

        public override EnumMovement ReturnMove(EnumMovement move)
        {
            return EnumMovement.NoMovement;
        }

        public override bool CheckRange(Character target)
        {
            if (this == target)
                return false;
            if (target.X == this.X || target.X == this.X - 1 || target.X == this.X + 1)
            {
                if (target.Y == this.Y || target.Y == this.Y - 1 || target.Y == this.Y + 1)
                    return true;
            }
            return false;
        }
    }
}
