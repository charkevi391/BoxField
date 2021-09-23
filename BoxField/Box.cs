using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxField
{
    class Box
    {
        public int x, y, size, speed, color;

        public Box(int _x, int _y, int _size, int _speed, int _color)
        {
            x = _x;
            y = _y;
            size = _size;   
            speed = _speed;
            color = _color; 
        }
    }
}
