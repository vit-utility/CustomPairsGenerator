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

            var result = new List<string>();

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }

                    result.Add($"{data[i]}/{data[j]}");
                }
            }

            File.WriteAllLines("result.txt", result);
        }
    }
}
