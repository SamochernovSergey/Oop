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
            using (StreamReader reader = new StreamReader("..\\..\\inputTxt.txt"))
            {
                List<int> numbers = new List<int>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] numbersStrings = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);                    
                    for (int i = 0; i < numbersStrings.Length; i++)
                    {
                        numbers.Add(Convert.ToInt32(numbersStrings[i]));                       
                    }                                       
                }
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
                numbers2.Add(numbers[0]);
                for (int i = 0; i < numbers.Count; i++)
                {
                    bool isDeleted = numbers.Remove(numbers2[i]);                    
                    while (isDeleted)
                    {
                        isDeleted = numbers.Remove(numbers2[i]);
                    }
                    numbers2.Add(numbers[0]);
                }
                Console.WriteLine("список без повторения чисел: ");
                Console.WriteLine(string.Join(",", numbers2));
            }
        }  
    }
}