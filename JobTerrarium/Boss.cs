using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTerrarium
{
    class Boss : Employee
    {
        public Boss(decimal salary, string name, bool mood, Point coordinate)
            : base(salary, name, mood, coordinate)
        { }

        public override string Say(string whatToSay)
        {
            return String.Format("Boss {0}. {1}", Name, whatToSay);
        }

        //public override string WhatToSay(Employee employee)
        //{
        //    if (employee == null)
        //        throw new ArgumentNullException("Employee is empty");

        //    if (employee is BigBoss)
        //        return "Good morning";
        //    if (employee is Boss)
        //        return "Hello";
        //    if (employee is Worker)
        //        return "Go to work!";
        //    else return "";
        //}

        public override string ToString()
        {
            return String.Format("Boss");
        }
    }
}
