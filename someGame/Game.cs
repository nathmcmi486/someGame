using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace someGame
{
    public partial class Game : UserControl
    {
        Random random = new Random();
        bool wDown = false;
        bool aDown = false;
        bool dDown = false;
        bool spaceDown;
        bool hDown;

        int randn(int min, int max)
        {
            return random.Next(min, max);
        }

        int part;
        Part[] gameParts = {
            // Part 0
            new Part(0,
                // Enemies
                new Person[] {
                    new Person(false, 80, 10, 500, 400, 10, Color.Orange),
                }
             ),
        };
        Person player = new Person(true, 150, 25, 30, 400, 14, Color.Green);

        public Game(int _partn)
        {
            InitializeComponent();
            part = _partn;
            gameParts[part].setupPart(player);
        }

        void gameLoop(object sender, EventArgs e)
        {
            if (wDown)
            {
                gameParts[part].player.up();
            }

            if (aDown)
            {
                gameParts[part].player.left();
            }

            if (dDown)
            {
                gameParts[part].player.right();
            }

            for (int i = 0; i < gameParts[part].enemies.Count(); i++)
            {
                gameParts[part].enemies[i].moveEnemy();
            }

            Refresh();
        }

        private void keyDownHandler(object sender, KeyEventArgs e)
        {
            this.debugLabel.Text = "keydown working!";
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.H:
                    hDown = true;
                    break;
                default:
                    break;
            }
        }

        void keyUpHandler(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.H:
                    hDown = false;
                    break;
                default:
                    break;
            }
        }

        void paintHandler(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Person enemy in gameParts[part].enemies)
            {
                Rectangle rect = new Rectangle(enemy.xPos, enemy.yPos, enemy.WIDTH, enemy.HEIGHT);
                g.FillRectangle(enemy.brush, rect);
            }

            Person currentPlayer = gameParts[part].player;
            Rectangle playerRect = new Rectangle(currentPlayer.xPos, currentPlayer.yPos, currentPlayer.WIDTH, currentPlayer.HEIGHT);
            g.FillRectangle(currentPlayer.brush, playerRect);
        }
    }
}
