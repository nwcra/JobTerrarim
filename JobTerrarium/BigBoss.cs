using System;
using System.Collections.Generic;
using System.Text;

namespace JobTerrarium
{
    class BigBoss :Boss
    {
        private Point position;

        public BigBoss(decimal salary, string name, bool mood, Point coordinate)
            : base(salary, name, mood, coordinate)
        { }

        public override string Say(string whatToSay)
        {
            return String.Format("Big Boss {0}. {1}", Name, whatToSay);
        }

        //public override string WhatToSay(Employee employee)
        //{
        //    if (employee == null)
        //        throw new ArgumentNullException("Employee is empty");

        //    if (employee is BigBoss)
        //        return "Hello";
        //    if (employee is Boss)
        //        return "The work?";
        //    if (employee is Worker)
        //        return "Go to work!";
        //    else return "";
        //}

        public override string ToString()
        {
            return "BigBoss";
        }
    }
}
