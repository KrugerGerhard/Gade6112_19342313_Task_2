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
    public partial class GameView : Form
    {
        GameEngine gameEngine;
        public GameView()
        {
            InitializeComponent();
            gameEngine = new GameEngine(6, 8, 6, 8, 5);
            updateMap();
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
                    else if (gameEngine.Map.NewMap[y, x] == null)
                    {
                        mapResult += $"{".",padWidth}";
                    }
                    else
                    {
                        if (gameEngine.Map.NewMap[y, x].tiletype0 == Tile.TileType.Hero)
                        {
                            mapResult += $"{"H",padWidth}";
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
            UpdateHeroStats();
        }

        private void UpdateHeroStats()
        {
            playerstats_label.Text = gameEngine.Map.Hero.ToString();
        }

        private void FrmGameView_Load(object sender, EventArgs e)
        {

        }

        private void FrmGameView_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("moved");

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                if (gameEngine.MovePlayer(Character.EnumMovement.Up))
                {
                    gameEngine.Map.UpdateVision();
                }
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                if (gameEngine.MovePlayer(Character.EnumMovement.Down))
                {
                    gameEngine.Map.UpdateVision();
                }
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                if (gameEngine.MovePlayer(Character.EnumMovement.Left))
                {
                    gameEngine.Map.UpdateVision();
                }
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                if (gameEngine.MovePlayer(Character.EnumMovement.Right))
                {
                    gameEngine.Map.UpdateVision();
                }
            }
            updateMap();
        }


    }
}
