using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightReadCsv
{
    class Csv
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("..\\..\\outputTable.html"))
            {
                using (StreamReader reader = new StreamReader("..\\..\\inputTable.csv", Encoding.GetEncoding(1251)))
                {
                    string text;
                    int stringsNumber = 0;
                    int columsNumber = 0;
                    string[,] cellArray =new string[stringsNumber, columsNumber];
                    string[] stringArray = new string[stringsNumber];
                    string[] columsArray = new string[columsNumber];
                    while ((text = reader.ReadLine()) != null)
                    {
                        Array.Resize<string>(ref stringArray, stringsNumber + 1);
                        stringArray[stringsNumber] = text;
                        ++stringsNumber;
                    }
                    for (int i = 0; i < stringsNumber; i++)
                    {
                        int firstIndex = 0;
                        string s = stringArray[i];
                        for (int j = firstIndex; j < s.Length; ++j)
                        {
                            if ((s[j] == ',') || (j  == s.Length))
                            {
                                Array.Resize<string>(ref columsArray, columsNumber + 1);
                                Console.WriteLine(firstIndex + "_" + j + "_" + s.Length);
                                columsArray[columsNumber] = s.Substring(firstIndex, j-firstIndex);
                                Console.WriteLine("ячейка № {0} = {1}", columsNumber, columsArray[columsNumber]);
                                Console.WriteLine();
                                ++columsNumber;
                                firstIndex = j+1;
                            }
                            else if (s[j] == '"')
                            {

                            }
                        }
                    }
                    writer.WriteLine("<table>");
                    writer.Write("</td> ");
                    writer.WriteLine("</tr>");
                    writer.Write("</table>");
                }
            }
        }
    }
}