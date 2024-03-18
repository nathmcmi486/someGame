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
        bool running = false;
        bool wDown = false;
        bool aDown = false;
        bool dDown = false;
        bool spaceDown = false;
        bool hDown = false;

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
            Thread.Sleep(3500);
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

            // this.debugLabel.Text = gameParts[part].bullets.Count() + "";

            for (int i = 0; i < gameParts[part].bullets.Count(); i++)
            {
                gameParts[part].bullets[i].move();

                if (gameParts[part].bullets[i].xPos < 0 || gameParts[part].bullets[i].xPos > 800)
                {
                    gameParts[part].bullets.RemoveAt(i);
                    continue;
                }

                if (gameParts[part].bullets[i].yPos < 0 || gameParts[part].bullets[i].yPos > 410)
                {
                    gameParts[part].bullets.RemoveAt(i);
                    continue;
                }
            }

            for (int i = 0; i < gameParts[part].enemies.Count(); i++)
            {
                gameParts[part].enemies[i].moveEnemy();
                if (gameParts[part].enemies[i].newBullet)
                {
                    gameParts[part].bullets.Add(gameParts[part].enemies[i].bullet);
                    gameParts[part].enemies[i].newBullet = false;
                }
            }

            Refresh();
        }

        public void keyDownHandler(object sender, KeyEventArgs e)
        {
            this.debugLabel.Text = "keydown working!";
            running = true;
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
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }
        }

        public void keyUpHandler(object sender, KeyEventArgs e)
        {
            this.debugLabel.Text = "keyup working!";
            running = true;
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
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }

        void paintHandler(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Using foreach stops key input
            for (int i = 0; i < gameParts[part].bullets.Count(); i++)
            {
                // this.debugLabel.Text = $"drawing bullet {i}";
                Rectangle rect = new Rectangle(gameParts[part].bullets[i].xPos, gameParts[part].bullets[i].yPos, gameParts[part].bullets[i].SIZE, gameParts[part].bullets[i].SIZE);
                g.FillRectangle(new SolidBrush(gameParts[part].bullets[i].color), rect);
            }

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
