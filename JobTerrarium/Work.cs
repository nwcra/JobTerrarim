using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobTerrarium
{
    public class Work : TerrariumObject
    {

        public Work(Point coordinate) : base(coordinate) { }

        public Point this[int index1, int index2]
        {
            get
            {
                if ((index1 <= 10 && index2 <= 10) && (index1 >= 1 && index2 >= 1))
                {
                    return Coordinate;
                }
                else
                {
                    throw new ArgumentException("Incorrect point");
                }
            }

            //set
            //{
            //    if ((index1 <= 20 && index2 <= 20) && (index1 >= 1 && index2 >= 1))
            //    {
            //        Coordinate[index1, index2] = value;
            //    }
            //    else
            //    {
            //        throw new ArgumentException("Incorrect point");
            //    }
            //}
        }

        public override string ToString()
        {
            return String.Format("Work");
        }
    }
}
