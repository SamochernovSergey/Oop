﻿using System;
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
            Console.WriteLine("список: ");
            s.PrintList();
            Console.WriteLine("разворот пустого списка");
            s.Reverse();
            s.PrintList();

            Console.WriteLine("удаление узла по значению Tommy , результат = {0}", s.RemoveByData("Tommy"));
            Console.WriteLine("список изменён: ");
            s.PrintList();

            s.InsertBegin("Tommy");
            s.InsertBegin("Boby");
            s.InsertBegin("Alice");
            s.InsertBegin("Billy");
            s.InsertBegin("Samy");
            s.InsertByIndex("Lois", 2);
            Console.WriteLine("Начальный список: ");
            s.PrintList();
            Console.WriteLine("получение размера списка = {0}", s.Count);

            string first = s.GetFirstElement();
            Console.WriteLine("получение значение первого элемента = {0}", first);

            Console.WriteLine("получение значения по указанному индексу 2 = {0} ", s.GetDataByIndex(2));

            Console.WriteLine("Изменение значения = Sonya по индексу 2 выдает старое значение: {0}", s.SetDataByIndex("Sonya", 2));
            Console.WriteLine("список изменён : ");
            s.PrintList();
            Console.WriteLine("удаление элемента по индексу, выдает значение элемента:1 = {0}", s.RemoveByIndex(0));
            Console.WriteLine("список изменён: ");
            s.PrintList();

            Console.WriteLine("вставка элемента Gogy в начало");
            s.InsertBegin("Gogy");
            Console.WriteLine("список изменён: ");
            s.PrintList();

            Console.WriteLine("вставка элемента null по индексу 6");
            string n = null;
            s.InsertByIndex(n, 5);
            Console.WriteLine("список изменён: ");
            s.PrintList();
            Console.WriteLine("удаление узла по значению null , результат = {0}", s.RemoveByData(n));
            Console.WriteLine("список изменён: ");
            s.PrintList();
            Console.WriteLine("удаление первого элемента, выдает значение элемента = {0}", s.RemoveBegin());
            Console.WriteLine("список: ");
            s.PrintList();
            Console.WriteLine("разворот списка за линейное время");
            s.Reverse();
            s.PrintList();
            Console.WriteLine("копирование списка ");
            SinglyLinkedList<string> copy = s.Copy();
            copy.PrintList();
            Console.WriteLine("Длинна Скопированного = {0}", copy.Count);
        }
    }
}