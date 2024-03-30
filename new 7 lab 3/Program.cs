using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_7_lab_3
{
    abstract class Team
    {
        private string name;
        private int[] place;
        private int[] ball;
        private int sum;
        private string gender;
        public Team(string name, int[] m, string gender)
        {
            this.gender = gender;
            this.name = name;
            place = new int[6];
            ball = new int[6];
            for (int i = 0; i < 6; i++)
            {
                place[i] = m[i];
                ball[i] = Math.Max(6 - place[i], 0);
            }
            sum = 0;
            initSum();
        }
        public virtual void print()
        {
            Console.WriteLine(name);
            for (int j = 0; j < 6; j++)
                Console.Write(place[j] + " ");
            Console.WriteLine();
            for (int i = 0; i < 6; i++)
                Console.Write(ball[i] + " ");
            Console.WriteLine();
            Console.WriteLine(sum);
        }
        private void initSum()
        {
            sum = 0;
            for (int i = 0; i < 6; i++)
                sum += ball[i];
        }
        public int getSum()
        {
            return sum;
        }
        public string getName()
        {
            return name;
        }
        public bool hasFirst()
        {
            for (int j = 0; j < 6; j++)
                if (place[j] == 1)
                    return true;
            return false;
        }
    }

    class WomenTeam : Team
    {
        public WomenTeam(string name, int[] m, string gender) : base(name, m, gender) { }
        public override void print()
        {
            Console.WriteLine("Women team");
            base.print();
        }
    }
    class MenTeam : Team
    {
        public MenTeam(string name, int[] m, string gender) : base(name, m, gender) { }
        public override void print()
        {
            Console.WriteLine("Men team");
            base.print();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int[] m = new int[6];
            int n = Convert.ToInt32(Console.ReadLine());
            MenTeam[] a = new MenTeam[n];
            for (int i = 0; i < a.Length; i++)
            {
                name = Console.ReadLine();
                for (int j = 0; j < m.Length; j++)
                    m[j] = Convert.ToInt32(Console.ReadLine());
                a[i] = new MenTeam(name, m, "M");
            }
            for (int i = 0; i < 3; i++)
                a[i].print();
            Console.WriteLine();
            int k1 = MaxBall(a);

            int d = Convert.ToInt32(Console.ReadLine());
            WomenTeam[] b = new WomenTeam[d];
            for (int i = 0; i < b.Length; i++)
            {
                name = Console.ReadLine();
                for (int j = 0; j < m.Length; j++)
                    m[j] = Convert.ToInt32(Console.ReadLine());
                b[i] = new WomenTeam(name, m, "W");
            }
            for (int i = 0; i < 3; i++)
                b[i].print();
            Console.WriteLine();
            int k2 = MaxBall(b);
            Team w, w2 = null;
            if (a[k1].getSum() > b[k2].getSum())
                w = a[k1];
            else if (a[k1].getSum() < b[k2].getSum())
                w = b[k2];
            else
                     if (a[k1].hasFirst() && !b[k2].hasFirst())
                w = a[k1];
            else if (b[k2].hasFirst() && !a[k1].hasFirst())
                w = b[k2];
            else
            {
                w = a[k1];
                w2 = b[k2];
            }
            Console.Write("Winner: ");
            w.print();
            if (w2 != null)
                w2.print();
        }
        static public int MaxBall(Team[] a)
        {
            int max = 0;
            int k = 0;
            for (int i = 0; i < 3; i++)
                if (a[i].getSum() > max)
                {
                    max = a[i].getSum();
                    k = i;
                }
            return k;
        }
    }
}
