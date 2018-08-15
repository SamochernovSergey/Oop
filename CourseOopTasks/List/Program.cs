using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<string> s = new SinglyLinkedList<string>();

            s.InsertBegin("Tom");
            s.InsertBegin("Bob");
            s.InsertBegin("Alice");
            s.InsertBegin("Bill");
            s.InsertBegin("Sam");
            Console.WriteLine("Первый в списке: ");
            Console.WriteLine(s.GetFirstElement());
            Console.WriteLine("Начальный список: ");
            s.PrintList();
            Console.WriteLine("Длинна = {0}",s.GetLength());
            SinglyLinkedList<string> copy = s.Copy();
            Console.WriteLine("Скопированный: ");
            copy.PrintList();
            Console.WriteLine("Длинна Скопированного = {0}", copy.GetLength());
            s.Reverse();
            Console.WriteLine("Перевернутый: ");
            s.PrintList();
            int x = 1;
            Console.WriteLine("InsertByIndex: Sonya {0}", x);
            s.InsertByIndex("Sonya", x);
            Console.WriteLine("список: ");
            s.PrintList();
            Console.WriteLine("SetDataByIndex: Sonya {0}", x);
            Console.WriteLine(s.SetDataByIndex("Sonya", x));
            Console.WriteLine("Элемент №{0}",x);
            Console.WriteLine("GetDataByIndex: ");
            Console.WriteLine(s.GetDataByIndex(x));
            Console.WriteLine("RemoveByIndex: ");
            Console.WriteLine(s.RemoveByIndex(x));
            Console.WriteLine("список: ");
            s.PrintList();
            Console.WriteLine("Скопированный: ");
            copy.PrintList();
            Console.WriteLine("Длинна Скопированного = {0}", copy.GetLength());
            Console.WriteLine("RemoveBegin: ");
            Console.WriteLine(s.RemoveBegin());
            Console.WriteLine("список: ");
            s.PrintList();
            Console.WriteLine("RemoveByData: Bill ");
            Console.WriteLine(s.RemoveByData("Bill"));
            Console.WriteLine("список: ");
            s.PrintList();

        }
    }
}