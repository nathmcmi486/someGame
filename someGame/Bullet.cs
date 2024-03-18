using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace someGame
{
    internal class Bullet
    {
        public int damage;
        public Color color;
        public bool movingRight;
        public int xPos;
        public int yPos;
        public double realYPos;
        public readonly int SIZE = 4;
        public bool isPlayerBullet;


        public Bullet(int _damage, bool _isPlayer, Color _color, bool _movingRight, int _xPos, int _yPos)
        {
            damage = _damage;
            color = _color;
            movingRight = _movingRight;
            xPos = _xPos;
            yPos = _yPos;
            realYPos = Convert.ToDouble(_yPos);
            isPlayerBullet = _isPlayer;
        }

        public void move()
        {
            realYPos += 0.2;
            yPos = Convert.ToInt32(realYPos);
            if (movingRight)
            {
                xPos += 3;
            } else
            {
                xPos -= 3;
            }
        }
    }
}
