using System;
using MaxSum.Application;
using System.Globalization;
using System.IO;

namespace MaxSum.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            ISum testSum = new MaxSumApplication();
            Console.WriteLine("Please, write full path of your file");
            string path;

            if (args?.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
            {
                path = args[0];
            }
            else
            {
                path = Console.ReadLine();
            }

            try
            {
                Console.WriteLine("The position of line with max sum:");
                var response = testSum.GetSumFromStrings(testSum.GetFile(path));

                var maxIndex = testSum.GetIndexOfMaxSum(response);
                Console.WriteLine($"{maxIndex}");

                Console.WriteLine("Numbers of broken lines:");

                foreach (var c in response)
                {
                    if (c.Broken)
                    {
                        Console.WriteLine(c.LineNumber);
                    }
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
