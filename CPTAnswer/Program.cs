using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var result = 0;
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            if (input.Length - input.Replace("1", "").Length > 1)
                result++;
        }
        Console.WriteLine(result);
    }
}
