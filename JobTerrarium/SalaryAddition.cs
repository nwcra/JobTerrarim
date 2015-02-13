using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTerrarium
{
    public class SalaryAddition : TerrariumObject
    {
        public SalaryAddition(Point coordinate) : base(coordinate) { }

        public override string ToString()
        {
            return String.Format("Salary++");
        }
    }
}
