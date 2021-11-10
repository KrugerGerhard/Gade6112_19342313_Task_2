using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    [System.Serializable()]
    class Hero : Character
    {
        EnumMovement HeroMovement;

        public Hero(int x, int y, int hp, int damage = 2, char symbol = 'H') : base( x, y, hp, 2, 'H')
        {
            this.tiletype0 = TileType.Hero;
            this.hp = 40;
            this.MaxHP = HP;
            this.damage = 2;
        }

        public override EnumMovement ReturnMove(EnumMovement move)
        {

            if (move == EnumMovement.Up)
            {
                HeroMovement = EnumMovement.Up;
            }
            else if (move == EnumMovement.Down)
            {
                HeroMovement = EnumMovement.Down;
            }
            else if (move == EnumMovement.Left)
            {
                HeroMovement = EnumMovement.Left;
            }
            else if (move == EnumMovement.Right)
            {
                HeroMovement = EnumMovement.Right;
            }
            else if (move == EnumMovement.NoMovement)
            {
                HeroMovement = EnumMovement.NoMovement;
            }

            return HeroMovement;
        }

        public override string ToString()
        {
            return "Player Stats:\n" + "HP: " + hp + "/" + MaxHP + "\nGold: " + purse + "\nDamage: 2\n" + "[" + Y + "," + X + "]";
        }
    }
}
