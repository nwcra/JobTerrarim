using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTerrarium
{
    public class TerrariumObject
    {
        protected Point coordinate;

        public Point Coordinate
        {
            get { return coordinate;}
        }

        public TerrariumObject(Point point)
        {
            coordinate = point;
        }

        public void Movie(Point point)
        {
            coordinate = point;
        }
    }
}
