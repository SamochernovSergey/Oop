using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int> table = new HashTable<int>(15)
            {
                11,
                22,
                33,
                88,
                44,
                55,
                77,
                99
            };

            table.Remove(88);
            table.Add(55);
            Console.WriteLine(table);

            foreach (var e in table)
            {
                Console.WriteLine(e);                
            }

            Console.WriteLine();

            int[] p = new int[20];

            table.CopyTo(p, 9);

            Console.WriteLine("CopyTo");

            foreach (int e in p)
            {
                Console.WriteLine(e);
            }
        }
    }
}