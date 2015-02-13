using System;
using System.Collections.Generic;
using System.Text;

namespace JobTerrarium
{
    internal class Worker : Employee
    {
        public Worker(decimal salary, string name, bool mood, Point coordinate)
            : base(salary, name, mood, coordinate)
        { }

        //public override string WhatToSay(Employee employee)
        //{
        //    if (employee == null)
        //        throw new ArgumentNullException("Employee is empty");

        //    if (employee is BigBoss)
        //        return "Hello, big boss";
        //    if (employee is Boss)
        //        return "Hello";
        //    if (employee is Worker)
        //        return "Hi";
        //    else return "";
        //}
        public override string Say(string whatToSay)
        {
            return String.Format("Worker {0}. {1}", Name, whatToSay);
        }

        public override string ToString()
        {
            return String.Format("Worker");
        }

        //public string WhatToSay
    }
}
