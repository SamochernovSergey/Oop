﻿using System;
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
            if (args.Length < 2)
            {
                Console.WriteLine("Для правильной работы программы необходимо ввести два аргумента");
                Console.WriteLine("первый аргумент путь и название файла откуда берутся данные");
                Console.WriteLine("второй аргумент путь и название файла куда данные надо записать");

                return;
            }
            using (StreamWriter writer = new StreamWriter(args[1]))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(args[0]))
                    {
                        bool quotedText = false;
                        StringBuilder stringBuilder = new StringBuilder();
                        writer.WriteLine("<!DOCTYPE html>");
                        writer.WriteLine("<html>");
                        writer.WriteLine("<head>");
                        writer.WriteLine("<meta charset=\"utf-8\">");
                        writer.WriteLine("<title>Таблица из Csv файла</title>");
                        writer.WriteLine("</head>");
                        writer.WriteLine("<body>");
                        writer.WriteLine("<table border=\"5\">");                        

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (!quotedText)
                            {
                                stringBuilder.Append("<tr>").AppendLine().Append("<td>");
                            }
                            for (int i = 0; i < line.Length; ++i)
                            {
                                if (line[i] == '<')
                                {
                                    stringBuilder.Append("&lt;");
                                    continue;
                                }
                                if (line[i] == '>')
                                {
                                    stringBuilder.Append("&gt;");
                                    continue;
                                }
                                if (line[i] == '&')
                                {
                                    stringBuilder.Append("&amp;");
                                    continue;
                                }
                                if (line[i] == '"')
                                {                                    
                                    if (!quotedText)
                                    {
                                        quotedText = true;
                                        continue;
                                    }
                                    else if ((i != line.Length - 1) && line[i + 1] == '"')
                                    {
                                        ++i;
                                        stringBuilder.Append(line[i]);
                                        continue;
                                    }
                                    else
                                    {
                                        quotedText = false;
                                        continue;
                                    }                                    
                                }
                                else if (!quotedText && line[i] == ',')
                                {
                                    stringBuilder.Append("</td>").AppendLine().Append("<td>");
                                }
                                else
                                {
                                    stringBuilder.Append(line[i]);
                                }
                            }
                            if (!quotedText)
                            {
                                stringBuilder.Append("</td>").AppendLine().Append("</tr>").AppendLine();
                            }
                            else
                            {
                                stringBuilder.Append("<br/>");
                            }
                        }

                        writer.WriteLine(stringBuilder);
                        stringBuilder.Clear();
                        writer.WriteLine("</table>");
                        writer.WriteLine("</body>");
                        writer.WriteLine("</html>");
                    }
                }
                catch (FileNotFoundException)
                {
                    writer.WriteLine("Файл Отсутствует");
                }
                finally
                {
                    Console.WriteLine("Всё готово");
                }
            }
        }
    }
}