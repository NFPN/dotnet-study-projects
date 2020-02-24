using System;

namespace Study1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test()
        {
            Console.WriteLine("Hello");

            int year = 2020;
            int day = 2;


            Console.WriteLine("We are in the year: " + year + " day: " + day + " !");

            Console.WriteLine("We are in the year: {0} day: {1} !", year, day);

            Console.WriteLine($"We are in the year: {year} day: {day} !");


            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
