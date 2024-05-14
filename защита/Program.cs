using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _8_lab
{
    public abstract class Task
    {
        protected string text;
        public Task(string text)
        {
            this.text = text;
        }
        public override string ToString()
        { return text; }
    }
    public class Task8 : Task
    {
        private string[] a;
        private int size;
        public Task8(string text) : base(text)
        {
            a = new string[50];
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < size; i++)
                res += a[i] + "|\n";
            return res;
        }
        public void Split()
        {
            int j = 0;
            int beg = 0, end = beg + 49, spaces = 0, places = 0, kol = 0, ost = 0;
            string s;
            while (end < text.Length)
            {
                if (end + 1 < text.Length && text[end + 1] == ' ')
                {
                    a[j] = text.Substring(beg, end - beg + 1);
                    j++;
                }
                else
                {
                    while (text[end] != ' ')
                    {
                        end--;
                    }
                    end--;	//чтобы = не было пробела
                    s = text.Substring(beg, end - beg + 1);
                    spaces = 50 - s.Length;

                    string[] b = s.Split(' ');
                    places = b.Length - 1;
                    kol = spaces / places + 1;
                    ost = spaces % places;
                    s = "";
                    for (int i = 0; i < b.Length - 1; i++)
                    {
                        if (ost > 0)
                        {
                            s = s + b[i] + new String(' ', kol + 1);
                            ost--;
                        }
                        else
                            s = s + b[i] + new String(' ', kol);
                    }
                    s += b[b.Length - 1];
                    a[j] = s;
                    j++;
                }
                beg = end + 1;
                if (text[beg] == ' ')
                    beg++;
                end = beg + 49;
            }
            a[j] = text.Substring(beg, text.Length - beg);
            j++;
            size = j;
        }
    }
    public struct Pair
    {
        public string first;
        public char second;

        public Pair(string f, char s)
        {
            first = f;
            second = s;
        }
        public string GetFirst()
        {
            return first;
        }
        public void SetFirst(string f)
        {
            first = f;
        }
        public char GetSecond()
        {
            return second;
        }
        public void SetSecond(char s)
        {
            second = s;
        }
    }

    public class Task9 : Task
    {
        public struct Freq
        {
            public string text;
            public int number;
        }
        protected Pair[] c;
        protected string encodedString;
        private int freq = 8;
        public Pair[] getC()
        {
            return c;
        }
        public Task9(string text) : base(text) { }
        public override string ToString()
        {
            return encodedString;
        }
        public void coding()
        {
            int len = 0;
            string tmp;
            int t = 0;
            Freq[] b = new Freq[500];
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (Char.IsLetter(text[i]) && Char.IsLetter(text[i + 1]))
                {
                    tmp = text.Substring(i, 2);
                    bool flag = true;
                    for (int k = 0; k < t; k++)
                    {
                        if (String.Compare(b[k].text, tmp) == 0)
                        {
                            b[k].number++;
                            flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        b[t].text = tmp;
                        b[t].number = 1;
                        t++;
                    }
                }
            }
            for (int i = 0; i < t; i++)
                if (b[i].number >= freq)     //10
                    len++;
            c = new Pair[len];
            int j = 0;
            string replace;
            for (int i = 0; i < t; i++)
                if (b[i].number >= freq)
                {   //10
                    c[j].first = b[i].text;
                    Console.WriteLine("Enter new symbol for " + c[j].first);
                    replace = Console.ReadLine();
                    c[j].second = replace[0];
                    j++;
                }
            encodedString = text;
            for (int i = 0; i < c.Length; i++)
                encodedString = encodedString.Replace(c[i].first, new String(c[i].second, 1));
        }
    }
    public class Task10 : Task
    {
        private Pair[] c;
        private string decodedString;
        public Task10(string text, Pair[] c) : base(text)
        {
            this.c = new Pair[c.Length];
            for (int i = 0; i < c.Length; i++)
            {
                this.c[i].first = c[i].first;
                this.c[i].second = c[i].second;
            }
        }
        public override string ToString()
        {
            return decodedString;
        }
        public void decoding()
        {
            decodedString = text;
            for (int i = 0; i < c.Length; i++)
                decodedString = decodedString.Replace(new String(c[i].second, 1), c[i].first);
        }
    }
    public class Task12 : Task
    {
        private Pair[] c;
        private string decodedString;

        public Task12(string text, Pair[] c) : base(text)
        {
            text = ReplaceCode(text, c);
            decodedString = text;
            this.c = new Pair[c.Length];
            for (int i = 0; i < c.Length; i++)
            {
                this.c[i].first = c[i].first;
                this.c[i].second = c[i].second;
            }
        }
        public override string ToString()
        {
            return decodedString;
        }
        public void decoding()
        {
            decodedString = text;
            for (int i = 0; i < c.Length; i++)
                decodedString = decodedString.Replace(new String(c[i].second, 1), c[i].first);
        }
        public string ReplaceCode(string text, Pair[] c)
        {
            for (int i = 0; i < c.Length; i++)
                text = text.Replace(c[i].first, new String(c[i].second, 1));
            return text;
        }
    }
    public class Task13 : Task
    {
        private List<char> letters = new List<char>(); // cписок символов
        private List<int> Count = new List<int>(); // список целых чисел

        public Task13(string text) : base(text) { }

        public void Percent(string text)
        {
            bool flag = true;

            foreach (char i in text)
            {
                if (char.IsLetter(i))
                {
                    char letter = char.ToLower(i);

                    if (flag)
                    {
                        int index = letters.IndexOf(letter);

                        if (index == -1) // есть ли текущая буква в списке
                        {
                            letters.Add(letter);
                            Count.Add(1);
                        }
                        else
                        {
                            Count[index]++;
                        }

                        flag = false;
                    }
                }
                else
                {
                    flag = true;
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            int sumLetters = Count.Sum();

            for (int i = 0; i < letters.Count; i++)
            {
                double percentage = (double)Count[i] / sumLetters * 100;

                result += $"{char.ToUpper(letters[i])}: {percentage:F2}%\n"; // формирование строки с результатом для каждой буквы 
            }
            return result;
        }
    }

    public class Task15 : Task
    {
        private int sum;
        private int x;
        public Task15(string text) : base(text)
        {
            x = 0;
            sum = 0;
        }
        public override string ToString()
        {
            return Convert.ToString(sum);
        }
        public void CalcSum()
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    x = 0;
                    while (i < text.Length && Char.IsDigit(text[i]))
                    {
                        x = x * 10 + (int)text[i] - (int)'0';
                        i++;
                    }
                    sum += x;
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            string text1 = Console.ReadLine();
            Task8 task = new Task8(text1);
            task.Split();
            Console.WriteLine("Task 8");
            Console.WriteLine(task);

            string text2 = Console.ReadLine();
            Task9 task9 = new Task9(text2);
            task9.coding();
            Console.WriteLine("Task 9");
            Console.WriteLine(task9);
            Console.WriteLine();

            Task10 task10 = new Task10(Convert.ToString(task9), task9.getC());
            task10.decoding();
            Console.WriteLine("Task 10");
            Console.WriteLine(task10);
            Console.WriteLine();

            string text3 = Console.ReadLine();
            Pair[] russian = new Pair[10] { new Pair("добыча", '@'), new Pair("древесины", '#'), new Pair("ученые", '$'), new Pair("рост", '%'), new Pair("движение", '^'), new Pair("системы", '&'), new Pair("Принцип", '*'), new Pair("когда", '{'), new Pair("роль", '}'), new Pair("свое", '|') };
            Pair[] english = new Pair[6] { new Pair("English", '@'), new Pair("Hamlet", '#'), new Pair("Othello", ')'), new Pair("was", '{'), new Pair("with", '%'), new Pair("early", '&'), };
            Task12 task12 = new Task12(text3, russian);
            //Task12 task12 = new Task12(text3,english);
            Console.WriteLine();
            Console.WriteLine("Task 12 before encoding");
            Console.WriteLine(task12);
            Console.WriteLine();
            task12.decoding();
            Console.WriteLine("Task 12 after decoding");
            Console.WriteLine(task12);
            Console.WriteLine();

            string text4 = Console.ReadLine();
            //Task13 task13 = new Task13(text4, true);    //true - флаг на английский, false - на русский язык убрала это
            Task13 task13 = new Task13(text4);
            task13.Percent(text4);
            Console.WriteLine("Task 13");
            Console.WriteLine(task13);
            Console.WriteLine();

            string text5 = Console.ReadLine();
            Task15 task15 = new Task15(text5);
            task15.CalcSum();
            Console.WriteLine("Task 15");
            Console.WriteLine(task15);
            Console.WriteLine();
        }
    }
}

