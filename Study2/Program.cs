using System;

namespace Study2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int value = 15;

            int anotherValue = 2;

            Console.WriteLine($"{ value / anotherValue }");


            var maxValue = int.MaxValue;
            Console.WriteLine($"{maxValue}");
            Console.WriteLine($"{maxValue + 1}");

            Console.ReadKey();

        }
    }
}