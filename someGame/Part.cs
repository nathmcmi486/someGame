using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace someGame
{
    internal class Part
    {
        public int partNumber;
        public Person[] enemies;
        public Person player;
        public bool setup;
        public List<Bullet> bullets = new List<Bullet>();

        public Part(int _partNumber, Person[] _enemies)
        {
            partNumber = _partNumber;
            enemies = _enemies;
        }

        public void setupPart(Person _player)
        {
            player = _player;
            setup = true;
        }
    }
}
