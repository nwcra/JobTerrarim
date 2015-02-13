using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTerrarium
{
    abstract class Employee: TerrariumObject
    {
        protected decimal Salary { get; set; }

        protected string Name;

        protected bool Mood;

        public Employee(decimal salary, string name, bool mood, Point point): base(point)
        {
            this.Salary = salary;
            this.Name = name;
            this.Mood = mood;
            this.coordinate = point;
        }

        public void AddSalaryAddition(int salaryAddition)
        {
            if (this.Salary + salaryAddition < MainForm.maxSalary)
            {
                this.Salary += salaryAddition;
            }
        }

        public abstract string Say(string whatToSay);

        //public abstract string WhatToSay(Employee employee);
    }
}
