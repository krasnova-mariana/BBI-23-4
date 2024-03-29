using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_lab_2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter kind of sport (1 - figure skating, 2 - speed skating):");
            int kind = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter discipline name:");
            string sportName = Console.ReadLine();
            Wintersport[] a = new Wintersport[5];
            string name;
            double[] b = new double[7];
            for (int i = 0; i < a.Length; i++)
            {
                name = Console.ReadLine();
                for (int j = 0; j < 7; j++)
                    b[j] = Convert.ToDouble(Console.ReadLine());
                if (kind == 1)
                    a[i] = new FigureSkating(name, b, sportName);
                else
                    a[i] = new SpeedSkating(name, b, sportName);
            }
            initPlaces(a);
            for (int i = 0; i < a.Length; i++)
                a[i].calcSum();
            FinishPlacesSort(a);
            Console.WriteLine("Discipline Name: " + a[0].getDisciplinename());
            //Console.WriteLine("Discipline Name: " + Wintersport.getDisciplinename());
            for (int i = 0; i < a.Length; i++)
                a[i].DisplayInfo();
        }
        static void initPlaces(Wintersport[] a)
        {
            for (int j = 0; j < 7; j++)
            {
                double[] b = new double[a.Length];
                int[] p = new int[a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    b[i] = a[i].getBall(j);
                    p[i] = i;
                }
                bubbleSort(b, p);
                for (int i = 0; i < a.Length; i++)
                {
                    a[p[i]].setPlace(j, i + 1);       //a[p[i]].place[j] = i+1;
                }
            }
        }
        static void bubbleSort(double[] b, int[] p)
        {
            int tmp;
            double tmpd;
            for (int step = 1; step < b.Length; step++)
                for (int i = b.Length - 1; i >= step; i--)
                    if (b[i] > b[i - 1])
                    {
                        tmpd = b[i];
                        b[i] = b[i - 1];
                        b[i - 1] = tmpd;
                        tmp = p[i];
                        p[i] = p[i - 1];
                        p[i - 1] = tmp;
                    }
        }
        static void FinishPlacesSort(Wintersport[] a)
        {
            Wintersport tmp;
            for (int step = 1; step < a.Length; step++)
                for (int i = a.Length - 1; i >= step; i--)
                    if (a[i].getSum() < a[i - 1].getSum())
                    {
                        tmp = a[i];
                        a[i] = a[i - 1];
                        a[i - 1] = tmp;
                    }
        }
    }
    abstract class Wintersport
    {
        private string name;
        private double[] ball;
        private int[] place;
        private int sum;
        private string disciplinename;
        //private static string disciplinename;
        public Wintersport(string name, double[] b, string disciplinename)
        {
            this.name = name;
            ball = new double[7];
            place = new int[7];
            for (int j = 0; j < 7; j++)
                ball[j] = b[j];
            sum = 0;
            this.disciplinename = disciplinename;
        }
        public string getDisciplinename()
        {
            return disciplinename;
        }
        public double getBall(int j)
        {
            return ball[j];
        }
        public void setPlace(int j, int pl)
        {
            place[j] = pl;
        }
        public int getSum()
        {
            return sum;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine(name);
            for (int j = 0; j < 7; j++)
                Console.Write(ball[j] + " ");
            Console.WriteLine();
            for (int j = 0; j < 7; j++)
                Console.Write(place[j] + " ");
            Console.WriteLine();
            Console.WriteLine("Sum: " + sum);
            //Console.WriteLine("Discipline Name: " + disciplinename);
        }
        public void calcSum()
        {
            sum = 0;
            for (int j = 0; j < 7; j++)
                sum += place[j];
        }
    }
    class FigureSkating : Wintersport
    {
        public FigureSkating(string name, double[] b, string disciplinename) : base(name, b, disciplinename) { }
        public override void DisplayInfo()
        {
            Console.WriteLine("Figure Skating");
            base.DisplayInfo();
        }
    }
    class SpeedSkating : Wintersport
    {
        public SpeedSkating(string name, double[] b, string disciplinename) : base(name, b, disciplinename) { }
        public override void DisplayInfo()
        {
            Console.WriteLine("Speed Skating");
            base.DisplayInfo();
        }
    }
}
