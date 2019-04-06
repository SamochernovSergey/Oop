using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            Console.WriteLine(strings);

            List<int> list = new List<int>(9);
            Console.WriteLine(list);

            List<int> myList = new List<int>
            {
                14,
                45,
                78,
                57,
                9,
                10,
                11,
                12,
                13,
                14
            };
            Console.WriteLine(myList);
            Console.WriteLine("myList.Insert(9, 99)");
            myList.Insert(9, 99);
            Console.WriteLine(myList);

            /*Console.WriteLine(myList.Contains(99));
            Console.WriteLine(myList.Contains(100));
            Console.WriteLine(myList);

            int x = myList[3];
            Console.WriteLine(x);

            myList[3] = 188;
            Console.WriteLine(myList);
            Console.WriteLine("Элемент в списке 78, находится по индексу = {0}", myList.IndexOf(78));

            myList.Add(33);
            myList.Add(34);
            Console.WriteLine(myList);

            Console.WriteLine(myList.Remove(99));

            myList.RemoveAt(9);
            Console.WriteLine(myList);

            Console.WriteLine("Проверка итератора");

            foreach (int e in myList)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("конец проверки итератора");
            Console.WriteLine("проверка TrimExcess");
            myList.Capacity = 120;
            Console.WriteLine("до TrimExcess");
            Console.WriteLine(myList);

            myList.TrimExcess();
            Console.WriteLine("после TrimExcess");
            Console.WriteLine(myList);

            int[] p = { 1, 2, 3, 4, 5, 6, 7 };
            List<int> list2 = new List<int>(p);
            Console.WriteLine(list2);

            int[] myList2 = new int[20];
            list2.CopyTo(myList2,2);

            foreach (int e in myList2)
            {
                Console.WriteLine(e);
            }

            list2.Clear();
            Console.WriteLine(list2);*/
        }
    }
}