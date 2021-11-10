using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19342313_G_Kruger_GADE6112_TASK1
{
    [System.Serializable()]
    public partial class GameView : Form
    {
        GameEngine gameEngine;
        FileRead fileRead = new FileRead();
        FileWrite fileWrite = new FileWrite();
        public GameView()
        {
            InitializeComponent();
            gameEngine = new GameEngine(6, 8, 6, 8, 5,5);
            updateMap();
            combatlog_label.Text = "Combat Information:";
        }

        public void Save()
        {
            fileWrite.WriteData<Map>(gameEngine.Map);
        }

        public void updateMap()
        {
            string mapResult = "";
            const int padWidth = 5;

            for (int y = 0; y < gameEngine.Map.NewMap.GetLength(0); y++)
            {
                for (int x = 0; x < gameEngine.Map.NewMap.GetLength(1); x++)
                {
                    if (y == 0 || x == 0 || y == gameEngine.Map.NewMap.GetLength(0) - 1 || x == gameEngine.Map.NewMap.GetLength(1) - 1)
                    {
                        mapResult += $"{"X",padWidth}";
                    }
                    else if (gameEngine.Map.NewMap[ x , y ] == null)
                    {
                        mapResult += $"{".",padWidth}";
                    }
                    else
                    {
                        if (gameEngine.Map.NewMap[ x , y ].tiletype0 == Tile.TileType.Hero)
                        {
                            mapResult += $"{"H",padWidth}";
                        }
                        if (gameEngine.Map.NewMap[y, x].tiletype0 == Tile.TileType.Gold)
                        {
                            mapResult += $"{"g",padWidth}";
                        }
                        else
                        {
                            mapResult += $"{"G",padWidth}";
                        }
                    }

                }
                mapResult += "\n\n";
            }
            map_label.Text = mapResult;
            updateHeroStats();
            updateAttackTargets();
            updateEnemyStats();
        }

        private void updateHeroStats()
        {
            playerstats_label.Text = gameEngine.Map.Hero.ToString();
        }

        private void Attack(Character target)
        {
            gameEngine.Map.Hero.Attack(target);
            combatlog_label.Text = "Combat Information:\n" + ((Enemy)target).ToString();
            if (target.IsDead())
            {
                combatlog_label.Text = "Combat Information:";
                gameEngine.Map.NewMap[target.Y, target.X] = null;
            }
            gameEngine.EnemyAttacks();
            RemoveEnemies();
            updateMap();
        }

        private void RemoveEnemies()
        {
            for (int i = 0; i < gameEngine.Map.Enemies.Length; i++)
            {
                if (gameEngine.Map.Enemies[i].IsDead())
                {
                    gameEngine.Map.NewMap[gameEngine.Map.Enemies[i].Y, gameEngine.Map.Enemies[i].X] = null;
                    gameEngine.Map.Enemies[i] = null;
                }
            }
            gameEngine.Map.Enemies = gameEngine.Map.Enemies.Where(thisClass => thisClass != null).ToArray();
        }

        private void updateEnemyStats()
        {
            string output = "";
            foreach (var enemy in gameEngine.Map.Enemies)
            {
                output += enemy.ToString() + "\n";
            }
            enemiesstats_label.Text = "Enemy Data:\n" + output;
        }
          //Removed the Keyboard move method due to being unable to get them working, will stay as such until POE
          //private void FrmGameView_KeyDown(object sender, KeyEventArgs e)
          //{
          //  Console.WriteLine("moved");
          //
          //  if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
          //  {
          //      if (gameEngine.MovePlayer(Character.EnumMovement.Up))
          //      {
          //          gameEngine.Map.UpdateVision();
          //      }
          //  }
          //  if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
          //  {
          //      if (gameEngine.MovePlayer(Character.EnumMovement.Down))
          //      {
          //          gameEngine.Map.UpdateVision();
          //      }
          //  }
          //  if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
          //   {
          //       if (gameEngine.MovePlayer(Character.EnumMovement.Left))
          //        {
          //          gameEngine.Map.UpdateVision();
          //        }
          //  }
          //  if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
          //  {
          //      if (gameEngine.MovePlayer(Character.EnumMovement.Right))
          //      {
          //          gameEngine.Map.UpdateVision();
          //      }
          //  }
          //  updateMap();
          //  }

        private void updateAttackTargets()
        {
            gameEngine.Map.UpdateVision();
            btnAttackUp.Enabled = false;
            btnAttackDown.Enabled = false;
            btnAttackRight.Enabled = false;
            btnAttackLeft.Enabled = false;
            if (gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Up - 1] != null)
                if (gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Up - 1].tiletype0 == Tile.TileType.Enemy)
                {
                    btnAttackUp.Enabled = true;
                }
            if (gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Down - 1] != null)
                if (gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Down - 1].tiletype0 == Tile.TileType.Enemy)
                {
                    btnAttackDown.Enabled = true;
                }
            if (gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Left - 1] != null)
                if (gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Left - 1].tiletype0 == Tile.TileType.Enemy)
                {
                    btnAttackLeft.Enabled = true;
                }
            if (gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Right - 1] != null)
                if (gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Right - 1].tiletype0 == Tile.TileType.Enemy)
                {
                    btnAttackRight.Enabled = true;
                }
        }

        private void BtnAttackUp_Click(object sender, EventArgs e)
        {
            Attack((Character)gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Up - 1]);
        }

        private void BtnAttackDown_Click(object sender, EventArgs e)
        {
            Attack((Character)gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Down - 1]);
        }

        private void BtnAttackLeft_Click(object sender, EventArgs e)
        {
            Attack((Character)gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Left - 1]);
        }

        private void BtnAttackRight_Click(object sender, EventArgs e)
        {
            Attack((Character)gameEngine.Map.Hero.Vision[(int)Character.EnumMovement.Right - 1]);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (gameEngine.MovePlayer(Character.EnumMovement.Up, gameEngine.Map.Hero))
            {
                gameEngine.EnemiesMove();
                RemoveEnemies();
                updateMap();
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (gameEngine.MovePlayer(Character.EnumMovement.Down, gameEngine.Map.Hero))
            {
                gameEngine.EnemiesMove();
                RemoveEnemies();
                updateMap();
            }
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if (gameEngine.MovePlayer(Character.EnumMovement.Left, gameEngine.Map.Hero))
            {
                gameEngine.EnemiesMove();
                RemoveEnemies();
                updateMap();
            }
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            if (gameEngine.MovePlayer(Character.EnumMovement.Right, gameEngine.Map.Hero))
            {
                gameEngine.EnemiesMove();
                RemoveEnemies();
                updateMap();
            }
        }
         //Unsure if Save and Load Functions work, due to being unable to get the buttons to display on the form itself
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        //Should work as intended
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadFile();
        }
        private void LoadFile()
        {
            gameEngine.Map = (Map)fileRead.ReadData<Map>();
            updateMap();
        }

        private void btnAttackUp_Click_1(object sender, EventArgs e)
        {

        }
    }
}
