using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobTerrarium
{
    public struct Point
    {
        private int x;

        private int y;

        public int X
        {
            set
            {
                if (value > 0 && value <= 20)
                {
                    x = value;
                }
            }
            get
            {
                return x;
            }
        }

        public int Y
        {
            set
            {
                if (value > 0 && value <= 20)
                {
                    y = value;
                }
            }
            get
            {
                return y;
            }
        }

        public Point(int px, int py)
        {
            this.x = px;
            this.y = py;
        }

        public override string ToString()
        {
            return String.Format("[{0}, {1}]", x, y);
        }
    }
}
