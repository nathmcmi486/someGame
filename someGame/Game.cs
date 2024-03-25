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
        bool running = false;
        bool wDown = false;
        bool aDown = false;
        bool dDown = false;
        bool spaceDown = false;
        bool hDown = false;

        int part;
        int level;
        Part[] gameParts = {
            // Part 0
            new Part(0,
                // Enemies
                new Person[]
                {
                    new Person(false, 80, 8, 500, 400, 10, Color.Orange),
                }
            ),
            new Part(1,
                // Enemies
                new Person[]
                {
                    new Person(false, 80, 8, 550, 400, 8, Color.Orange),
                    new Person(false, 130, 5, 570, 400, 9, Color.DarkOrange),
                }
            ),
            new Part(2,
                new Person[]
                {
                    new Person(false, 80, 8, 600, 400, 8, Color.Orange),
                    new Person(false, 350, 22, 590, 400, 3, Color.DarkOrange)
                }
            )
        };

        Part[][] levels =
        {
            new Part[] {
                // Part 0
                new Part(0,
                    // Enemies
                    new Person[]
                    {
                        new Person(false, 80, 8, 500, 400, 10, Color.Orange),
                    }
                ),
                new Part(1,
                    // Enemies
                    new Person[]
                    {
                        new Person(false, 80, 8, 550, 400, 8, Color.Orange),
                        new Person(false, 130, 5, 570, 400, 9, Color.DarkOrange),
                    }
                ),
                new Part(2,
                    new Person[]
                    {
                        new Person(false, 80, 8, 600, 400, 8, Color.Orange),
                        new Person(false, 350, 22, 590, 400, 3, Color.DarkOrange)
                    }
                )
            },
            new Part[]
            {
                new Part(0,
                    new Person[]
                    {
                        new Person(false, 999, 50, 820, 20, 5, Color.White),
                    }
                ),
                new Part(1,
                    new Person[]
                    {
                        new Person(false, 999, 50, 620, 20, 5, Color.White),
                        new Person(false, 80, 8, 820, 400, 8, Color.Orange),
                    }
                ),
                new Part(1,
                    new Person[]
                    {
                        new Person(false, 999, 50, 800, 20, 5, Color.White),
                        new Person(false, 80, 8, 820, 30, 8, Color.Orange),
                        new Person(false, 130, 5, 700, 400, 9, Color.DarkOrange)
                    }
                ),
                new Part(2,
                    new Person[]
                    {
                        new Person(false, 999, 50, 800, 20, 5, Color.White),
                        new Person(false, 999, 50, 800, 20, 3, Color.White),
                        new Person(false, 350, 22, 820, 30, 3, Color.DarkOrange),
                    }
                )
            },
        };

        Person player = new Person(true, 150, 12, 30, 400, 14, Color.Green);

        public Game(int _partn, int _leveln)
        {
            InitializeComponent();

            Thread.Sleep(1500);

            running = true;
            part = _partn;
            level = _leveln;
            switch (level)
            {
                case 0:
                    levels[level][part].setupPart(player);
                    break;
                case 1:
                    player = new Person(true, 150, 12, 30, 400, 14, Color.Green);
                    player.healCount = 5;
                    player.bullets = 200;
                    levels[level][part].setupPart(player);

                    break;
                default:
                    break;
            }
        }

        void gameLoop(object sender, EventArgs e)
        {
            if (running == false)
            {
                return;
            }

            if (part == 2 && levels[level][part].enemies.Count() == 0)
            {
                this.Controls.Add(this.debugLabel);
                this.debugLabel.Text = "Level 1 completed!\nMove on to start next level";
            }

            if (level == 1 && part == 3 && levels[level][part].enemies.Count() == 2)
            {
                this.Controls.Add(this.debugLabel);
                this.debugLabel.Text = "Level 2 completed!\nYou win!";

                levels[level][part].player.up();
                Random rand = new Random();
                if (rand.Next(0, 101) > 50)
                {
                    levels[level][part].player.left();
                } else
                {
                    levels[level][part].player.right();
                    if (levels[level][part].player.xPos > this.Width - 50)
                    {
                        levels[level][part].player.xPos -= 50;
                    }
                }
            }

            int currentPart = part;
            int currentLevel = level;

            // This seems to allow key input to work, there's a lot of assumptions I have for why this happens but they
            // might not be right
            System.Diagnostics.Process[] procs = System.Diagnostics.Process.GetProcesses();
            this.healthLabel.Text = $"Health: {levels[level][part].player.health}";
            this.healLabel.Text = $"Heal (h): {levels[level][part].player.healCount}";
            this.bulletCountLabel.Text = $"Bullets: {levels[level][part].player.bullets}";
            this.partNumberLabel.Text = $"Level: {level + 1}\nPart: {part + 1}";

            if (wDown)
            {
                levels[level][part].player.up();
            }

            if (aDown)
            {
                levels[level][part].player.left();
                if (levels[level][part].player.xPos < 10)
                {
                    levels[level][part].player.xPos = 10;
                }
            }

            if (dDown)
            {
                levels[level][part].player.right();

                if (levels[level][part].player.xPos > this.Width - 50)
                {
                    currentPart += 1;
                }
            }

            if (hDown && levels[level][part].player.healCount > 0)
            {
                levels[level][part].player.healCount -= 1;
                levels[level][part].player.health += 30;
                hDown = false;
            }

            if (part != currentPart)
            {
                Person currentPlayer = levels[level][part].player;
                player.xPos = 30;
                part += 1;

                // Part specific stuff
                if (level == 0)
                {
                    switch (part)
                    {
                        case 1:
                            player.bullets += 25;
                            player.healCount += 1;
                            break;
                        case 2:
                            player.bullets += 50;
                            player.healCount += 2;
                            break;
                        case 3:
                            level += 1;
                            part = 0;
                            player.health = 150;
                            player.healCount = 5;
                            player.bullets = 200;
                            break;
                        default:
                            break;
                    }
                }

                this.Controls.Remove(this.debugLabel);
                levels[level][part].setupPart(currentPlayer);
                return;
            }

            if (part == 2 && level == 0 && levels[0][2].enemies.Count() == 0)
            {
                this.debugLabel.Text = "Level 1 Complete!\nContinue right to start Level 2";
            }

            if (spaceDown)
            {
                Person player = levels[level][part].player;
                if (player.bullets > 0)
                {
                    Bullet newBullet = new Bullet(player.damage, true, Color.Red, player.facingRight, player.xPos, player.yPos);
                    newBullet.playerBulletXSpeed = 5;
                    levels[level][part].bullets.Add(newBullet);
                    spaceDown = false;
                    levels[level][part].player.bullets -= 1;
                }
            }

            if (levels[level][part].player.health <= 0)
            {
                this.Controls.Remove(this.debugLabel);
                this.debugLabel.Text = "You died! Press escape to close.";
                //running = false;
                for (int i = 0; i < levels[level][part].enemies.Count(); i++)
                {
                    levels[level][part].enemies[i].enemyMoves.Add(2);
                    levels[level][part].player.health = 0;
                }
            }

            Rectangle playerRect = new Rectangle(levels[level][part].player.xPos, levels[level][part].player.yPos, levels[level][part].player.WIDTH, levels[level][part].player.HEIGHT);

            // this.debugLabel.Text = levels[level][part].bullets.Count() + "";

            for (int i = 0; i < levels[level][part].bullets.Count(); i++)
            {
                levels[level][part].bullets[i].move();

                if (levels[level][part].bullets[i].xPos < 0 || levels[level][part].bullets[i].xPos > 800)
                {
                    levels[level][part].bullets.RemoveAt(i);
                    continue;
                }

                if (levels[level][part].bullets[i].yPos < 0 || levels[level][part].bullets[i].yPos > 410)
                {
                    levels[level][part].bullets.RemoveAt(i);
                    continue;
                }

                Bullet currentBullet = levels[level][part].bullets[i];
                Rectangle bulletRect = new Rectangle(currentBullet.xPos, currentBullet.yPos, currentBullet.SIZE, currentBullet.SIZE);

                if (!levels[level][part].bullets[i].isPlayerBullet)
                {
                    if (bulletRect.IntersectsWith(playerRect))
                    {
                        levels[level][part].player.health -= currentBullet.damage;
                        levels[level][part].bullets.RemoveAt(i);
                        continue;
                    }
                } else
                {
                    for (int j = 0; j < levels[level][part].enemies.Count(); j++)
                    {
                        Person currentEnemy = levels[level][part].enemies[j];
                        Rectangle enemyRect = new Rectangle(currentEnemy.xPos, currentEnemy.yPos, currentEnemy.WIDTH, currentEnemy.HEIGHT);

                        if (bulletRect.IntersectsWith(enemyRect))
                        {
                            levels[level][part].enemies[j].health -= currentBullet.damage;
                            levels[level][part].bullets.RemoveAt(i);
                            continue;
                        }
                    }
                }
            }

            for (int i = 0; i < levels[level][part].enemies.Count(); i++)
            {
                if (levels[level][part].enemies[i].health <= 0)
                {
                    List<Person> tmpEnemyList = new List<Person>(levels[level][part].enemies);
                    tmpEnemyList.RemoveAt(i);
                    levels[level][part].enemies = tmpEnemyList.ToArray();
                    continue;
                }

                levels[level][part].enemies[i].moveEnemy();
                if (levels[level][part].enemies[i].newBullet)
                {
                    if (levels[level][part].player.health > 0)
                    {
                        levels[level][part].bullets.Add(levels[level][part].enemies[i].bullet);
                        levels[level][part].enemies[i].newBullet = false;
                    }
                }

                if (levels[level][part].enemies[i].xPos > this.Width - 50)
                {
                    levels[level][part].enemies[i].xPos -= 50;
                } else if (levels[level][part].enemies[i].xPos < 0 + 10) {
                    if (levels[level][part].enemies[i].health == 999)
                    {
                        if (part == 0)
                        {
                            levels[level][part].enemies[i] = new Person(false, 80, 8, 600, 400, 8, Color.Orange);
                        } else if (part == 1 || part == 2)
                        {
                            levels[level][part].enemies[i] = new Person(false, 999, 50, 820, 100, 5, Color.White);
                        }
                    }
                    levels[level][part].enemies[i].xPos += 10;
                } 
            }

            Refresh();
        }

        public void keyDownHandler(object sender, KeyEventArgs e)
        {
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
            for (int i = 0; i < levels[level][part].bullets.Count(); i++)
            {
                // this.debugLabel.Text = $"drawing bullet {i}";
                Rectangle rect = new Rectangle(levels[level][part].bullets[i].xPos, levels[level][part].bullets[i].yPos, levels[level][part].bullets[i].SIZE, levels[level][part].bullets[i].SIZE);
                g.FillRectangle(new SolidBrush(levels[level][part].bullets[i].color), rect);
            }

            foreach (Person enemy in levels[level][part].enemies)
            {
                Rectangle rect = new Rectangle(enemy.xPos, enemy.yPos, enemy.WIDTH, enemy.HEIGHT);
                g.FillRectangle(enemy.brush, rect);
            }

            Person currentPlayer = levels[level][part].player;
            if (currentPlayer.health > 0)
            {
                Rectangle playerRect = new Rectangle(currentPlayer.xPos, currentPlayer.yPos, currentPlayer.WIDTH, currentPlayer.HEIGHT);
                g.FillRectangle(currentPlayer.brush, playerRect);
            }
        }
    }
}
