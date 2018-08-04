using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("..\\..\\intText.txt"))
            {
                string line = reader.ReadToEnd();
                string[] splits = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int count = splits.Length;
                int[] numbers = new Int32[count];
                ArrayList<int> numerals = new ArrayList<int>();
                for (int i = 0; i < count; ++i)
                {
                    numbers[i] = Convert.ToInt32(splits[i]);
                    numerals.Add(numbers[i]);

                }
            }
        }
    }
}