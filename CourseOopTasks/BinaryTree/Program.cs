using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> TreeOfLife = new Tree<int>(8);
                                    
            TreeOfLife.Insert(3);
            TreeOfLife.Insert(1);
            TreeOfLife.Insert(6);            
            TreeOfLife.Insert(4);
            TreeOfLife.Insert(7);
            TreeOfLife.Insert(10);
            TreeOfLife.Insert(14);
            TreeOfLife.Insert(15);
            
            //Console.WriteLine(TreeOfLife.Count);            
            /*Console.WriteLine("node = 99 - {0}",TreeOfLife.Properties(99));
            Console.WriteLine("node = 108 - {0}", TreeOfLife.Properties(108));
            Console.WriteLine("node = 80 - {0}", TreeOfLife.Properties(80));
            Console.WriteLine("node = 106 - {0}", TreeOfLife.Properties(106));
            Console.WriteLine("node = 85 - {0}", TreeOfLife.Properties(85));
            Console.WriteLine("node = 81 - {0}", TreeOfLife.Properties(81));
            
            Console.WriteLine("node = 99 - {0}", TreeOfLife.Properties(99));
            Console.WriteLine("node = 106 - {0}", TreeOfLife.Properties(106));
            Console.WriteLine("node = 108 - {0}", TreeOfLife.Properties(108));
            Console.WriteLine("node = 107 - {0}", TreeOfLife.Properties(107));
            Console.WriteLine("node = 109 - {0}", TreeOfLife.Properties(109));
            Console.WriteLine("удаляем 108", TreeOfLife.Delete(108));
            Console.WriteLine("node = 109 - {0}", TreeOfLife.Properties(109));
            Console.WriteLine("node = 74 - {0}", TreeOfLife.Properties(74));
            Console.WriteLine("удаляем 73", TreeOfLife.Delete(73));
            Console.WriteLine("node = 70 - {0}", TreeOfLife.Properties(70));
            Console.WriteLine("node = 74 - {0}", TreeOfLife.Properties(74));*/
            
            /*foreach(var e in TreeOfLife.StepWidth())
            {
                Console.WriteLine(e);
            }*/

            /*foreach (var e in TreeOfLife.StepDeep())
            {
                Console.WriteLine(e);
            }*/

            foreach (var e in TreeOfLife.RecursiveStepDeep())
            {
                Console.WriteLine(e);
            }
        }
    }
}
