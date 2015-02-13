using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTerrarium
{
    public delegate void EmployeeSay(object sender, string sayText , EventArgs e);
    public delegate void EmployeeSalaryAddiction(object sender, EventArgs e);

    class Terrarium
    {
        private TerrariumObject[,] terrarium;

        private Dictionary<Tuple<Type, Type>, string> sayDictonary = new Dictionary<Tuple<Type, Type>, string>();

        public event EmployeeSay Say;
        public event EmployeeSalaryAddiction employeeSalaryAddiction;

        public TerrariumObject this[int index1, int index2]
        {
            get
            {
                if ((index1 >= MainForm.rowsSize) || (index2 >= MainForm.columnSize) || (index1 < 0) || (index2 < 0))
                    throw new ArgumentException("Invalid coorditate");

                return terrarium[index1, index2];
            }
            set
            {
                if ((index1 >= MainForm.rowsSize && index2 >= MainForm.columnSize) && (index1 <= 0 && index2 <= 0) && (value == null))
                    throw new ArgumentException("Invalid coorditate");

                terrarium[index1, index2] = value;
            }
        }

        public Terrarium()
        { 
            terrarium = new TerrariumObject[MainForm.rowsSize, MainForm.columnSize];

            //sayDictonary = new Dictionary<Tuple<Type, Type>, string>();

            sayDictonary.Add(new Tuple<Type, Type>(typeof(BigBoss), typeof(BigBoss)), "The work?");
            sayDictonary.Add(new Tuple<Type, Type>(typeof(BigBoss), typeof(Worker)), "Go to work!");
            sayDictonary.Add(new Tuple<Type, Type>(typeof(BigBoss), typeof(Boss)), "The work?");
            sayDictonary.Add(new Tuple<Type, Type>(typeof(Boss), typeof(Boss)), "Hello");
            sayDictonary.Add(new Tuple<Type, Type>(typeof(Boss), typeof(Worker)), "Go to work!");
            sayDictonary.Add(new Tuple<Type, Type>(typeof(Boss), typeof(BigBoss)), "Goog morning");
            sayDictonary.Add(new Tuple<Type, Type>(typeof(Worker), typeof(BigBoss)), "Goog morning");
            sayDictonary.Add(new Tuple<Type, Type>(typeof(Worker), typeof(Boss)), "Hello");
            sayDictonary.Add(new Tuple<Type, Type>(typeof(Worker), typeof(Worker)), "Hi");
        }

        public void Add(TerrariumObject tobject)
        {
            if ((tobject == null))
                throw new ArgumentNullException("Empty object");

            terrarium[tobject.Coordinate.X, tobject.Coordinate.Y] = tobject;
        }

        private Point GetRandomEmptyCoorditate()
        {
            int x = MainForm.RandomValue();
            int y = MainForm.RandomValue();

            if (terrarium[x, y] == null)
            {
                return new Point(x, y);
            }
            else
                return GetRandomEmptyCoorditate();
        }

        private List<Point> GetFreeAllSpace()
        {
            var list = new List<Point>();

            for (int i = 0; i < MainForm.rowsSize; i++)
            {
                for (int j = 0; j < MainForm.columnSize; j++)
                {
                    if (terrarium[i, j] == null)
                    {
                        Point p = new Point(i, j);
                        list.Add(p);
                    }
                }
            }

            return list;
        }

        private List<TerrariumObject> GetEmployees()
        {
            var employeesList = new List<TerrariumObject>();

            for (int i = 0; i < MainForm.rowsSize; i++)
            {
                for (int j = 0; j < MainForm.columnSize; j++)
                {
                    if (terrarium[i, j] is Employee)
                    {
                        employeesList.Add(terrarium[i, j]);
                    }
                }
            }

            return employeesList;
        }

        private List<Point> GetAllWorkCoordinates()
        {
            var workList = new List<Point>();

            for (int i = 0; i < MainForm.rowsSize; i++)
            {
                for (int j = 0; j < MainForm.columnSize; j++)
                {
                    if (terrarium[i, j] is Work)
                    {
                        workList.Add(new Point(i, j));
                    }
                }
            }

            return workList;
        }

        private List<Point> GetAllSalaryAddictionCoordinates()
        {
            var workList = new List<Point>();

            for (int i = 0; i < MainForm.rowsSize; i++)
            {
                for (int j = 0; j < MainForm.columnSize; j++)
                {
                    if (terrarium[i, j] is SalaryAddition)
                    {
                        workList.Add(new Point(i, j));
                    }
                }
            }

            return workList;
        }

        private Point GetFreeSpace()
        {
            var listFreePoint = GetFreeAllSpace();

            if(listFreePoint.Count == 0)
                throw new ArgumentNullException("Terrarium doesn't contain free space");

            Random random = new Random();
            int rnd = random.Next(0, listFreePoint.Count);

            return listFreePoint[rnd];
        }

        private List<Point> PointAround(int x, int y)
        {
            List<Point> aroundCoordinates = new List<Point>();
            //aroundCoordinates.Add(new Point(x - 1, y - 1));
            //aroundCoordinates.Add(new Point(x - 1, y));
            //aroundCoordinates.Add(new Point(x - 1, y + 1));
            //aroundCoordinates.Add(new Point(x, y - 1));
            //aroundCoordinates.Add(new Point(x, y + 1));
            //aroundCoordinates.Add(new Point(x + 1, y - 1));
            //aroundCoordinates.Add(new Point(x + 1, y));
            //aroundCoordinates.Add(new Point(x + 1, y + 1));

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int newX = x + i;
                    int newY = y + j;
                    if(!((i == 0) && (j == 0)) && (newX >=0) && (newX < MainForm.columnSize) && (newY >= 0) && (newY < MainForm.rowsSize))
                    {
                        aroundCoordinates.Add(new Point(newX, newY));
                    }
                }
            }

                return aroundCoordinates;
        }

        private Point GetFreeSpace(int x, int y)
        {
            var listFreePoint = GetFreeAllSpace();

            List<Point> freeCoordinatesAround = new List<Point>(); // the intersection of two areas: 
            // the free and those that are in the neighborhood

            List<Point> aroundCoordinates = PointAround(x, y);

            Point point = new Point(x, y);

            if (listFreePoint.Count == 0)
                throw new ArgumentNullException("Terrarium doesn't contain free space");

            foreach(var around in aroundCoordinates)
            {
                foreach (var list in listFreePoint)
                {
                    if ((around.X == list.X) && (around.Y == list.Y))
                    {
                        freeCoordinatesAround.Add(around);
                    }
                }
            }

            if (freeCoordinatesAround.Count == 0)
                return point;

            Random random = new Random();
            int rnd = random.Next(0, freeCoordinatesAround.Count);

            return freeCoordinatesAround[rnd];
        }

        private Point GetWork(int x, int y)
        {
            List<Point> aroundCoordinates = PointAround(x, y);
            List<Point> allWork = GetAllWorkCoordinates();

            foreach(var around in aroundCoordinates)
            {
                foreach(var work in allWork)
                {
                    if ((around.X == work.X) && (around.Y == work.Y))
                    {
                        return new Point(around.X, around.Y);
                    }
                }
            }

            return new Point(x, y);
        }

        private Point GetSalaryAddiction(int x, int y)
        {
            List<Point> aroundCoordinates = PointAround(x, y);
            List<Point> allSalaryAddiction = GetAllSalaryAddictionCoordinates();

            foreach (var around in aroundCoordinates)
            {
                foreach (var salaryAddiction in allSalaryAddiction)
                {
                    if ((around.X == salaryAddiction.X) && (around.Y == salaryAddiction.Y))
                    {
                        return new Point(around.X, around.Y);
                    }
                }
            }

            return new Point(x, y);
        }

        private void DoWork(Point point)
        {
            Point work = GetWork(point.X, point.Y);
            if (!((work.X == point.X) && (work.Y == point.Y)))
            {
                Point free = GetFreeSpace();
                terrarium[work.X, work.Y].Movie(free);
                terrarium[free.X, free.Y] = terrarium[work.X, work.Y];
                terrarium[work.X, work.Y] = null;

                terrarium[point.X, point.Y].Movie(work);
                terrarium[work.X, work.Y] = terrarium[point.X, point.Y];
                terrarium[point.X, point.Y] = null;
            }
            else
                DoMovie(point);
        }

        private void DoMovie(Point point)
        {
            Point free = GetFreeSpace(point.X, point.Y);
            if ((free.X != point.X) && (free.Y != point.Y))
            {
                terrarium[point.X, point.Y].Movie(free);
                terrarium[free.X, free.Y] = terrarium[point.X, point.Y];
                terrarium[point.X, point.Y] = null;
            }
        }

        private string WhatToSay(Type mytype, Type youType)
        {
            string say = null;
            Tuple<Type, Type> tuple = Tuple.Create(mytype, youType);
            if (sayDictonary.ContainsKey(tuple))
            {
                say = Convert.ToString(sayDictonary[tuple]);
            }

            return say;
        }

        protected virtual string OnSay(string sayText)
        { 
            if(Say != null)
            {
                EventArgs args = new EventArgs();
                Say(this, sayText , args);
            }
            return sayText;
        }

        protected virtual void OnSalaryAddiction()
        {
            if (employeeSalaryAddiction != null)
            {
                EventArgs args = new EventArgs();
                employeeSalaryAddiction(this, args);
            }
        }

        private void DoSay(Point point)
        {
            List<Point> pointAround = PointAround(point.X, point.Y);

            Type myType = terrarium[point.X, point.Y].GetType();

            foreach (var arround in pointAround)
            {
                if (terrarium[arround.X, arround.Y] is Employee)
                {
                    var youType = terrarium[arround.X, arround.Y].GetType();
                    string whatToSay = WhatToSay(myType, youType);

                    if (terrarium[point.X, point.Y] is BigBoss)
                    {
                        BigBoss sayBigBoss = terrarium[point.X, point.Y] as BigBoss;
                        string say = sayBigBoss.Say(whatToSay);
                        OnSay(say);
                    }

                    if (terrarium[point.X, point.Y] is Boss)
                    {
                        Boss sayBoss = terrarium[point.X, point.Y] as Boss;
                        string say = sayBoss.Say(whatToSay);
                        OnSay(say);
                    }

                    if (terrarium[point.X, point.Y] is Worker)
                    {
                        Worker sayWorker = terrarium[point.X, point.Y] as Worker;
                        string say = sayWorker.Say(whatToSay);
                        OnSay(say);
                    }

                }
            }
        }

        public void DoAddSalary(Point point)
        {
            Point salaryAddiction = GetSalaryAddiction(point.X, point.Y);
            if (!((salaryAddiction.X == point.X) && (salaryAddiction.Y == point.Y)))
            {
                Point free = GetFreeSpace();
                terrarium[salaryAddiction.X, salaryAddiction.Y].Movie(free);
                terrarium[free.X, free.Y] = terrarium[salaryAddiction.X, salaryAddiction.Y];
                terrarium[salaryAddiction.X, salaryAddiction.Y] = null;

                var employee = terrarium[point.X, point.Y] as Employee;
                employee.AddSalaryAddition(100);
                OnSalaryAddiction();
                terrarium[point.X, point.Y].Movie(salaryAddiction);
                terrarium[salaryAddiction.X, salaryAddiction.Y] = terrarium[point.X, point.Y];
                terrarium[point.X, point.Y] = null;
            }
            else
                DoMovie(point);

        }
        public void Run()
        {
            var employeeList = GetEmployees();

            foreach(var emp in employeeList)
            {
                if (emp is Worker)
                {
                    DoWork(emp.Coordinate);
                    //DoMovie(emp.Coordinate);
                }
                else 
                {
                    DoMovie(emp.Coordinate);
                }

                DoAddSalary(emp.Coordinate);
                DoSay(emp.Coordinate);
            }
        }
    }
}
