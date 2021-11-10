using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    class GameEngine
    {
        private Map map;

        public Map Map
        {
            get => map;
        }

        public GameEngine(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyAmount)
        {
            map = new Map(minWidth, maxWidth, minHeight, maxHeight, enemyAmount);
        }

        public bool MovePlayer(Character.EnumMovement direction)
        {
            if (direction == Character.EnumMovement.Left)
            {
                if (map.Hero.X - 1 != 0 && map.Hero.Vision[2] == null)
                {
                    map.NewMap[map.Hero.Y, map.Hero.X] = null;
                    map.Hero.Move(Character.EnumMovement.Left);
                    map.NewMap[map.Hero.Y, map.Hero.X] = map.Hero;
                    return true;
                }
            }
            else if (direction == Character.EnumMovement.Right)
            {
                if (map.Hero.X + 2 != map.MapHeight && map.Hero.Vision[3] == null)
                {
                    map.NewMap[map.Hero.Y, map.Hero.X] = null;
                    map.Hero.Move(Character.EnumMovement.Right);
                    map.NewMap[map.Hero.Y, map.Hero.X] = map.Hero;
                    return true;
                }
            }
            else if (direction == Character.EnumMovement.Up)
            {
                if (map.Hero.Y - 1 != 0 && map.Hero.Vision[0] == null)
                {
                    map.NewMap[map.Hero.Y, map.Hero.X] = null;
                    map.Hero.Move(Character.EnumMovement.Up);
                    map.NewMap[map.Hero.Y, map.Hero.X] = map.Hero;
                    return true;
                }
            }
            else
            {
                if (map.Hero.Y + 2 != map.MapWidth && map.Hero.Vision[1] == null)
                {
                    map.NewMap[map.Hero.Y, map.Hero.X] = null;
                    map.Hero.Move(Character.EnumMovement.Down);
                    map.NewMap[map.Hero.Y, map.Hero.X] = map.Hero;
                    return true;
                }
            }
            return false;
        }


    }
}
