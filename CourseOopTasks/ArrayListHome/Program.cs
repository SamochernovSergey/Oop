using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListHome
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader("..\\..\\inputTxt.txt"))
                {
                    List<string> lines = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                    foreach (string s in lines)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл Отсутствует");
            }

            List<int> numbers = new List<int>
            {
                1,
                5,
                2,
                1,
                3,
                5,
                4,
                8,
                16,
                90,
                1,
                5,
                7,
                16,
                9,
                54,
                43
            };

            Console.WriteLine("исходный список: ");
            Console.WriteLine(string.Join(",", numbers));
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.RemoveAt(i);
                    --i;
                }
            }
            Console.WriteLine("список без чётных чисел: ");
            Console.WriteLine(string.Join(",", numbers));

            List<int> numbers2 = new List<int>();            
            for (int i = 0; i < numbers.Count; i++)
            {
                bool isContains = numbers2.Contains(numbers[i]);
                if (!isContains)
                {
                    numbers2.Add(numbers[i]);
                }
            }
            Console.WriteLine("список без повторения чисел: ");
            Console.WriteLine(string.Join(",", numbers2));
        }
    }
}