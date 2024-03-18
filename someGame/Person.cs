using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace someGame
{
    // Find beter name
    internal class Person
    {
        public int health;
        public int damage;
        public int xPos;
        public int yPos;
        public int speed;
        public Color color;
        public SolidBrush brush;
        bool player;
        public readonly int WIDTH = 20;
        public readonly int HEIGHT = 50;
        public readonly int GROUND = 400;
        public bool facingRight;

        // Only for the enemy
        const int RIGHT = 0;
        const int LEFT = 1;
        const int JUMP = 2;
        const int SHOOT = 3;
        public List<int> enemyMoves = new List<int>();
        public bool newBullet;
        public Bullet bullet;

        public Person(bool _player, int _health, int _damage, int _xPos, int _yPos, int _speed, Color _color)
        {
            health = _health;
            damage = _damage;
            xPos = _xPos;
            yPos = _yPos;
            speed = _speed;
            color = _color;
            brush = new SolidBrush(color);
            player = _player;
        }

        public void left()
        {
            facingRight = false;
            if (yPos < GROUND)
            {
                yPos += speed / 2;
            }
            xPos -= speed;
        }

        public void right()
        {
            facingRight = true;
            if (yPos < GROUND)
            {
                yPos += speed / 2;
            }
            xPos += speed;
        }

        public void up()
        {
            if (yPos == GROUND)
            {
                yPos -= speed * 2;
            }
        }

        public void moveEnemy()
        {
            if (player)
            {
                return;
            }

            if (yPos < GROUND)
            {
                yPos += speed / 2;
            }

            Random rand = new Random();
            int movesCount = enemyMoves.Count();

            if (movesCount < 3)
            {
                enemyMoves.Add(rand.Next(RIGHT, SHOOT + 1));
            } else
            {
                int lastMove = enemyMoves[movesCount - 1];
                int secondLastMove = enemyMoves[movesCount - 2];
                int thirdLastMove = enemyMoves[movesCount - 3];

                int[] possibleMoves =
                {
                    thirdLastMove,
                    secondLastMove,
                    lastMove,
                    lastMove,
                    (lastMove + secondLastMove + thirdLastMove) / 3,
                    RIGHT,
                    LEFT,
                    lastMove,
                    SHOOT,
                    lastMove,
                };

                enemyMoves.Add(possibleMoves[rand.Next(0, possibleMoves.Count())]);
            }

            int newMove = enemyMoves.Last();

            switch (newMove)
            {
                case RIGHT:
                    facingRight = true;
                    xPos -= speed;
                    break;
                case LEFT:
                    facingRight = false;
                    xPos += speed;
                    break;
                case JUMP:
                    if (yPos == GROUND)
                    {
                        yPos -= speed * 2;
                    }
                    break;
                case SHOOT:
                    newBullet = true;
                    bullet = new Bullet(damage, false, Color.DarkBlue, facingRight, xPos, yPos);
                    break;
                default:
                    break;
            }
        }
    }
}
