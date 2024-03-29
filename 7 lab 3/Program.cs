using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_lab_3
{
    abstract class Team
    {
        private string name;
        private int[] place;
        private int[] ball;
        private int sum;
        public Team(string name, int[] m)
        {
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
        private string gender;
        public WomenTeam(string name, int[] m, string gender) : base(name, m)
        {
            this.gender = gender;
        }
        public override void print()
        {
            Console.WriteLine("Women team");
            base.print();
        }
    }
    class MenTeam : Team
    {
        private string gender;
        public MenTeam(string name, int[] m, string gender) : base(name, m)
        {
            this.gender = gender;
        }
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
            Team[] a = new Team[3];
            string name;
            int[] m = new int[6];
            string gender;
            for (int i = 0; i < a.Length; i++)
            {
                name = Console.ReadLine();
                for (int j = 0; j < m.Length; j++)
                    m[j] = Convert.ToInt32(Console.ReadLine());
                gender = Console.ReadLine();
                if (gender[0] == 'm')            //"m", "male", "men"
                    a[i] = new MenTeam(name, m, gender);
                else
                    a[i] = new WomenTeam(name, m, gender);
            }
            for (int i = 0; i < 3; i++)
                a[i].print();
            Console.WriteLine();
            int k = MaxBall(a);
            Console.Write("Winner: ");
            a[k].print();
        }
        static public int MaxBall(Team[] a)
        {
            int max = 0;
            int k = 0, countMax = 0;
            for (int i = 0; i < 3; i++)
                if (a[i].getSum() > max)
                {
                    max = a[i].getSum();
                    countMax = 1;
                    k = i;
                }
                else if (a[i].getSum() == max)
                    countMax += 1;
            if (countMax > 1)
                for (int i = 0; i < 3; i++)
                    if (a[i].getSum() == max)
                    {
                        if (a[i].hasFirst() == true)
                            return i;
                    }
            return k;
        }
    }
}
