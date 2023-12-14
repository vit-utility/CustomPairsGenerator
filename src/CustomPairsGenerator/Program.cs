using System;
using System.Collections.Generic;
using System.IO;

namespace CustomPairsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Row> rows = new List<Row>();

            try
            {
                var data = File.ReadAllLines("source.txt");

                foreach (var item in data)
                {
                    if (item.StartsWith("*"))
                    {
                        var r = new Row { IgnoreInSecondPos = true, Data = item.Substring(1) };
                        rows.Add(r);
                    }
                    else
                    {
                        var r = new Row { Data = item };
                        rows.Add(r);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Bad data in source file or source file does not exist.");
                Console.WriteLine("Press any key");

                Console.ReadKey();
                return;
            }

            var result = new List<List<string>>();
            var current = new List<string>();
            result.Add(current);

            var count = 0;

            for (int i = 0; i < rows.Count; i++)
            {
                if (count + rows.Count >= 1000)
                {
                    current = new List<string>();
                    result.Add(current);

                    count = 0;
                }

                var s = rows[i].Data.IndexOf(":");

                current.Add($"###{rows[i].Data.Substring(s + 1)}");

                for (int j = 0; j < rows.Count; j++)
                {
                    if (j == i || rows[j].IgnoreInSecondPos)
                    {
                        continue;
                    }

                    current.Add($"{rows[i].Data}/{rows[j].Data}");
                    ++count;
                }                
            }

            count = 1;
            foreach (var item in result)
            {
                File.WriteAllLines($"result_{count}.txt", item);
                ++count;
            }
        }
    }

    public class Row
    {
        public string Data { get; set; }

        public bool IgnoreInSecondPos { get; set; }
    }
}
