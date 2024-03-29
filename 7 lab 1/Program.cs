using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_lab_1
{
    internal class Program
    {
        class Sportsmen
        {
            private string name;
            private double rez1;
            private double rez2;
            private bool isDisqualification;
            public Sportsmen(string name, double rez1, double rez2)
            {
                this.name = name;
                this.rez1 = rez1;
                this.rez2 = rez2;
                isDisqualification = false;
            }
            public void disqualification()
            {
                isDisqualification = true;
            }
            public bool getDisqualification()
            {
                return isDisqualification;
            }
            public double getRez1()
            {
                return rez1;
            }
            public double getRez2()
            {
                return rez2;
            }
            public void print()
            {
                Console.WriteLine(name + " " + rez1 + " " + rez2);
            }
        }
        static void delDisq(Sportsmen[] a, ref int n)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i].getDisqualification() == true)
                    count++;
                else if (count > 0)
                {
                    a[i - count] = a[i];
                }
            n -= count;      //везде использовать n вместо Length

        }
        static void Sort(Sportsmen[] a)
        {
            Sportsmen tmp;
            for (int step = 1; step < a.Length; step++)
                for (int i = a.Length - 1; i >= step; i--)
                    if (Math.Max(a[i].getRez1(), a[i].getRez2()) > Math.Max(a[i - 1].getRez1(), a[i - 1].getRez2()))
                    {
                        tmp = a[i];
                        a[i] = a[i - 1];
                        a[i - 1] = tmp;
                    }
        }
        static void Main()
        {
            Sportsmen[] a = new Sportsmen[5];
            string name;
            double r1, r2;
            for (int i = 0; i < a.Length; i++)
            {
                name = Console.ReadLine();
                r1 = Convert.ToDouble(Console.ReadLine());
                r2 = Convert.ToDouble(Console.ReadLine());
                a[i] = new Sportsmen(name, r1, r2);
            }
            for (int i = 0; i < a.Length; i++)
                a[i].print();
            Sort(a);
            for (int i = 0; i < a.Length; i++)
                a[i].print();
            int numb, x;
            Console.WriteLine("Enter number of disq sportsmens: ");
            numb = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numb; i++)
            {
                Console.WriteLine("Enter sportsmen number: ");
                x = Convert.ToInt32(Console.ReadLine());
                a[x].disqualification();
            }
            int n = a.Length;
            delDisq(a, ref n);
            for (int i = 0; i < n; i++)
                a[i].print();
        }
    }
}
