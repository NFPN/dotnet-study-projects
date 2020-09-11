using CompetetiveProgrammingTests.Base;
using System;

namespace CompetetiveProgrammingTests.ProblemSolution
{
    /// <summary>
    /// https://codeforces.com/problemset/problem/231/A
    /// </summary>
    public class ATeamSolver : ISolveProblem
    {
        public string Execute()
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
            return result.ToString();
        }
    }
}
