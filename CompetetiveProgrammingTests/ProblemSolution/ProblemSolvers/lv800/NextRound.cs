using CompetetiveProgrammingTests.Base;
using System;

namespace CompetetiveProgrammingTests.ProblemSolution
{
    /// <summary>
    /// https://codeforces.com/problemset/problem/158/A
    /// </summary>
    public class NextRound : ISolveProblem
    {
        public string Execute()
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
            return whoPassed.ToString();
        }
    }
}