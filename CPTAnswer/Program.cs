using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var info = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        var scores = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        var whoPassed = 0;

        if (scores[0] != 0)
        {
            var participants = info[0];
            var thresholdNum = info[1];
            var thresholdValue = scores[thresholdNum - 1];

            for (int i = 0; i < participants; i++)
                if (scores[i] >= thresholdValue && scores[i] > 0)
                    whoPassed++;
        }

        Console.WriteLine(whoPassed);
    }
}
