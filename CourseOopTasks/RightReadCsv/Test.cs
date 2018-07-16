using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightReadCsv
{
    class Test
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("..\\..\\outputTable.html"))
            {
                using (StreamReader reader = new StreamReader("..\\..\\input.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        bool flag = false;
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int i = 0; i < line.Length; ++i)
                        {
                            char c = line[i];

                            if (c == '"')
                            {
                                flag = true;                                
                            }
                            
                            stringBuilder.Append(i);
                            if (c == ',')
                            {
                                string cell = stringBuilder.ToString();
                                Console.WriteLine(cell);
                                Console.ReadKey();
                                writer.WriteLine(cell);
                            }
                                if (c == '"')
                            {
                                flag = false;
                            }
                            

                        }
                    }
                }
            }
        }
    }
}