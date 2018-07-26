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
                try
                {
                    using (StreamReader reader = new StreamReader("..\\..\\inputTable.csv", Encoding.GetEncoding(1251)))
                    {
                        bool flag = false;
                        StringBuilder stringBuilder = new StringBuilder();
                        writer.WriteLine("<Html>" + Environment.NewLine + "<Head>" + Environment.NewLine + "<Meta charset=utf-8>"
                            + Environment.NewLine + "<Title>Таблица из Csv файла</Title> " + Environment.NewLine + "</Head>"
                            + Environment.NewLine + "<Body>" + Environment.NewLine + "<Table border=5>" + Environment.NewLine + "<tr>"
                            + Environment.NewLine + "<td>");

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains("<"))
                            {
                                line = line.Replace("<", "&lt;");
                            }
                            if (line.Contains(">"))
                            {
                                line = line.Replace(">", "&gt;");
                            }
                            if (line.Contains("&"))
                            {
                                line = line.Replace("&", "&amp;");
                            }

                            for (int i = 0; i < line.Length; ++i)
                            {
                                if (line[i] == '"')
                                {
                                    if (i != line.Length - 1)
                                    {
                                        if (!flag)
                                        {
                                            flag = true;
                                        }
                                        else if (line[i] == '"' && line[i + 1] == '"')
                                        {
                                            stringBuilder.Append(line[i]);
                                            ++i;
                                        }
                                        else
                                        {
                                            flag = false;
                                        }
                                    }
                                }
                                else if (!flag && line[i] == ',')
                                {
                                    stringBuilder.Append("</td>").Append(Environment.NewLine).Append("<td>");
                                }
                                else
                                {
                                    stringBuilder.Append(line[i]);
                                }
                            }
                            if (!flag)
                            {
                                stringBuilder.Append("</td>").Append(Environment.NewLine).Append("</tr>").Append(Environment.NewLine).Append("<tr>").Append(Environment.NewLine).Append("<td>");
                            }
                            else
                            {
                                stringBuilder.Append("<br/>");
                            }
                        }
                        writer.WriteLine(stringBuilder);
                        stringBuilder.Clear();
                        writer.WriteLine("</Table>" + Environment.NewLine + "</Body>" + Environment.NewLine + "</Html>");
                    }
                }
                catch (FileNotFoundException)
                {
                    writer.WriteLine("Файл Отсутствует");
                }
            }
        }
    }
}