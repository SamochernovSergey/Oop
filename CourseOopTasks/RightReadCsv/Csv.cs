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
                        bool quotedText = false;
                        StringBuilder stringBuilder = new StringBuilder();
                        writer.WriteLine("<doctype>" + Environment.NewLine + "<html>" + Environment.NewLine + "<head>" 
                            + Environment.NewLine + "<meta charset=\"utf-8\">" + Environment.NewLine + "<title>Таблица из Csv файла</title>" 
                            + Environment.NewLine + "</head>" + Environment.NewLine + "<body>" + Environment.NewLine + "<table border=\"5\">" 
                            + Environment.NewLine + "<tr>" + Environment.NewLine + "<td>");

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            for (int i = 0; i < line.Length; ++i)
                            {
                                if (line[i] == '<')
                                {
                                    stringBuilder.Append("&lt;");
                                    ++i;
                                }
                                if (line[i] == '>')
                                {
                                    stringBuilder.Append("&gt;");
                                    ++i;
                                }
                                if (line[i] == '&')
                                {
                                    stringBuilder.Append("&amp;");
                                    ++i;
                                }
                                if (line[i] == '"')
                                {
                                    if (i != line.Length - 1)
                                    {
                                        if (!quotedText)
                                        {
                                            quotedText = true;
                                        }
                                        else if (line[i] == '"' && line[i + 1] == '"')
                                        {
                                            stringBuilder.Append(line[i]);
                                            ++i;
                                        }
                                        else
                                        {
                                            quotedText = false;
                                        }
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
                                stringBuilder.Append("</td>").AppendLine().Append("</tr>").AppendLine().Append("<tr>").AppendLine().Append("<td>");
                            }
                            else
                            {
                                stringBuilder.Append("<br/>");
                            }
                        }
                        writer.WriteLine(stringBuilder);
                        stringBuilder.Clear();
                        writer.WriteLine("</table>" + Environment.NewLine + "</body>" + Environment.NewLine + "</html>");
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