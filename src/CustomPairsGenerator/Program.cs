using System;
using System.Collections.Generic;
using System.IO;

namespace CustomPairsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = null;

            try
            {
                data = File.ReadAllLines("source.txt");
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

            for (int i = 0; i < data.Length; i++)
            {
                if (count + data.Length >= 1000)
                {
                    current = new List<string>();
                    result.Add(current);

                    count = 0;
                }

                var s = data[i].IndexOf(":");

                current.Add($"###{data[i].Substring(s + 1)}");

                for (int j = 0; j < data.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    current.Add($"{data[i]}/{data[j]}");
                }

                count += data.Length;
            }

            count = 1;
            foreach (var item in result)
            {
                File.WriteAllLines($"result_{count}.txt", item);
                ++count;
            }            
        }
    }
}
