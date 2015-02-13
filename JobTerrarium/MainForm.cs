using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Collections;
using System.Windows.Forms;

namespace JobTerrarium
{
    public partial class MainForm : Form
    {
        enum EmployeeName : int { Alex, Jay, Ann, Nick, Albert, Alise, Kristina, Lisa };

        public static readonly int rowsSize = 10;

        public static readonly int columnSize = 10;

        public static readonly int allWorks = 5;

        public static readonly int bigBossCount = 2;

        public static readonly int bossCount = 3;

        public static readonly int workerCount = 6;

        public static readonly int salaryAddictionCount = 5;

        public static readonly int maxSalary = 3600;

        public static readonly int minSalary = 100;

        public static readonly int dayTime = 100;

        private Terrarium terrarium = null;

        private ArrayList terrarriumList = null;

        public Dictionary<Type, string[]> whatToSayTable;


        private void InitializeDataGridView()
        {
            workSpace.Rows.Clear();

            workSpace.ColumnCount = columnSize;
            workSpace.RowCount = rowsSize;

            workSpace.Height = 224;
            workSpace.Width = 483;

            for (int i = 0; i < columnSize; i++)
            {
                workSpace.Columns[i].Width = 48;
            }

                workSpace.ColumnHeadersVisible = false;
            workSpace.RowHeadersVisible = false;

        }

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private EmployeeName GetRandomName()
        {
            Random rnd = new Random();
            EmployeeName randomName = (EmployeeName)rnd.Next(1, 8);
            return randomName;
        }

        private void ShowTable()
        {
            for (int i = 0; i < columnSize; i++)
            {
                for (int j = 0; j < rowsSize; j++)
                {
                    if (terrarium[i, j] != null)
                    {
                        workSpace[i, j].Value = terrarium[i, j].ToString();
                    }
                    else
                    {
                        workSpace[i, j].Value = String.Empty;
                    }
                }
            }
        }

        public static int RandomValue()
        {
            Random random = new Random();
            int x = random.Next(0, rowsSize);
            return x;
        }

        private static void Tick()
        {
            Thread.Sleep(1000);
        }

        private void CreateEmployee()
        {
            terrarriumList = new ArrayList();
            for (int i = 0; i < allWorks; i++)
            {
                int x = RandomValue();
                int y = RandomValue();
                if (terrarium[x, y] == null)
                {
                    Work work = new Work(new Point(x, y));
                    terrarriumList.Add(work);
                    terrarium.Add(work);

                }
                else { i--; }
            }

            for (int i = 0; i < salaryAddictionCount; i++)
            {
                int x = RandomValue();
                int y = RandomValue();
                if (terrarium[x, y] == null)
                {
                    SalaryAddition addiction = new SalaryAddition(new Point(x, y));
                    terrarriumList.Add(addiction);
                    terrarium.Add(addiction);

                }
                else { i--; }
            }

            for (int i = 0; i < bigBossCount; i++)
            {
                int x = RandomValue();
                int y = RandomValue();
                if (terrarium[x, y] == null)
                {
                    BigBoss bigBoss = new BigBoss(100, (GetRandomName()).ToString(), true, new Point(x, y));
                    terrarriumList.Add(bigBoss);
                    terrarium.Add(bigBoss);
                }
                else { i--; }
            }

            for (int i = 0; i < workerCount; i++)
            {
                int x = RandomValue();
                int y = RandomValue();
                if (terrarium[x, y] == null)
                {
                    Worker worker = new Worker(100, (GetRandomName()).ToString(), true, new Point(x, y));
                    terrarriumList.Add(worker);
                    terrarium.Add(worker);
                }
                else { i--; }
            }

            for (int i = 0; i < bossCount; i++)
            {
                int x = RandomValue();
                int y = RandomValue();
                if (terrarium[x, y] == null)
                {
                    Boss boss = new Boss(100, (GetRandomName()).ToString(), true, new Point(x, y));
                    terrarriumList.Add(boss);
                    terrarium.Add(boss);
                }
                else { i--; }
            }
        }

        private void RunTerrarium()
        {
            terrarium = new Terrarium();

            terrarium.Say += new EmployeeSay(SayHandler);
            terrarium.employeeSalaryAddiction += new EmployeeSalaryAddiction(SalaryAddictionHandler);

            CreateEmployee();

            ShowTable();
            Application.DoEvents();

            for (int i = 0; i < dayTime; i++)
            {
                terrarium.Run();

                ShowTable();
                Application.DoEvents();
                Tick();
            }
        }

        public void SayHandler(object sender, string sayText, EventArgs e)
        {
            logTalk.AppendText(sayText + Environment.NewLine);
        }

        public void SalaryAddictionHandler(object sender, EventArgs e)
        {
            logTalk.AppendText("Salary Add!!!" + Environment.NewLine);
        }

        private void RunTerrarium_Click(object sender, EventArgs e)
        {
            RunTerrarium();
        }
    }
}
