using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    [Serializable()]

    class GameEngine
    {
        private Map map;

        public Map Map
        {
            get => map;
        }

        public GameEngine(int minWidth, int maxWidth, int minHeight, int maxHeight, int enemyAmount, int goldPickUps)
        {
            map = new Map(minWidth, maxWidth, minHeight, maxHeight, enemyAmount, goldPickUps);
        }

        public bool MovePlayer(Character.EnumMovement direction, Character character)
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

        public void EnemiesMove()
        {
            foreach (var enemy in map.Enemies)
            {
                if (enemy.GetType() != typeof(Goblin))
                {
                    continue;
                }
                bool ableToMove = false;

                for (int i = 0; i < enemy.Vision.Length; i++)
                {
                    if (enemy.Vision[i] == null)
                    {
                        ableToMove = true;
                    }
                    if (enemy.Vision[i] != null && enemy.Vision[i].tiletype0 == Tile.TileType.Hero)
                        continue;
                }
                if (!ableToMove)
                    continue;

                MovePlayer((Character.EnumMovement)map.Random.Next(0, 4) + 1, enemy);
            }
        }
        public void EnemyAttacks() //Enemy Attack method should be functional in theory 
        {
            foreach (var enemy in map.Enemies)
            {
                if (enemy.CheckRange(map.Hero))
                {
                    enemy.Attack(map.Hero);
                }
                foreach (var e in map.Enemies)
                {
                    if (e == enemy)
                    {
                        continue;
                    }
                    if (enemy.CheckRange(e))
                    {
                        enemy.Attack(e);
                    }
                }
            }
        }
    }
}
