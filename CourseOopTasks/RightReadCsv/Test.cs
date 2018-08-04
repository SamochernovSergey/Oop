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
                using (StreamReader reader = new StreamReader("..\\..\\inputTable.csv", Encoding.GetEncoding(1251)))
                {
                    string line;
                    bool flag = false;
                    int j = 1;
                    StringBuilder stringBuilder = new StringBuilder();
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine("Это оригинальный текст: Строка № {0} ", j);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(line);
                        Console.ResetColor();
                        int s = 1;
                        for (int i = 0; i < line.Length; ++i)
                        {
                            if (flag && line[i] == '"')
                            {
                                flag = false;
                                continue;
                            }
                            if (line[i] == '"')
                            {
                                stringBuilder.Append(line[i]);
                                flag = true;
                                continue;
                            }
                            
                            if (line[i] == ','&& !flag)
                            {
                                string cell = stringBuilder.ToString();
                                Console.WriteLine("столбец №: {0}, строка №{1}", s, j);
                                ++s;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(cell);
                                Console.ResetColor();
                                stringBuilder.Clear();
                                if (i == line.Length - 1)
                                {
                                    cell = "";
                                    Console.WriteLine("столбец №: {0}, строка №{1}", s, j);
                                    ++s;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(cell);
                                    Console.ResetColor();
                                }
                                continue;
                            }
                            if (i == line.Length - 1 && !flag)
                            {
                                stringBuilder.Append(line[i]);
                                string cell = stringBuilder.ToString();
                                Console.WriteLine("столбец №: {0}, строка №{1}", s, j);
                                ++s;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(cell);
                                Console.ResetColor();
                                stringBuilder.Clear();
                                continue;
                            }


                            stringBuilder.Append(line[i]);
                            
                        }
                            ++j;
                    }

                    /* for (int i = 0; i < line.Length; ++i)
                     {
                         if (line[i] == '"' && !flag)
                         {
                             flag = true;
                         }
                          if (i == line.Length - 1 && !flag)
                            {
                                stringBuilder.Append(line[i]);
                                string cell = stringBuilder.ToString();
                                Console.WriteLine("столбец №: {0}, строка №{1}", s, j);
                                ++s;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(cell);
                                Console.ResetColor();
                                stringBuilder.Remove(0, cell.Length);
                                break;
                            }
                         stringBuilder.Append(line[i]);
                         if ((line[i] == ',' || i == line.Length - 1) && (!flag))

                         {
                             string cell = stringBuilder.ToString();
                             Console.WriteLine(cell);
                             Console.WriteLine(flag);
                             writer.WriteLine(cell);
                         }
                         
                         if (i == ',' && i == line.Length - 1 && !flag)
                            {
                                stringBuilder.Append("+ ");
                                string cell = stringBuilder.ToString();
                                Console.WriteLine("столбец №: {0}, строка №{1}", s, j);
                                ++s;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(cell);
                                Console.ResetColor();
                                stringBuilder.Remove(0, cell.Length);
                            }
                                 if (cell.Length == 0)
                                 {
                                     stringBuilder.Append("+");
                                 }
                     }*/
                }
            }
        }
    }
}