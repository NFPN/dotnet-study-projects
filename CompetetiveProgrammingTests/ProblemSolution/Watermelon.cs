using CompetetiveProgrammingTests.Base;
using System;

namespace CompetetiveProgrammingTests.ProblemSolution
{
    public class WatermelonSolver : ISolveProblem
    {
        /// <summary>
        /// https://codeforces.com/problemset/problem/4/A
        /// </summary>
        public WatermelonSolver() { }

        public string Execute()
        {
            var w = int.Parse(Console.ReadLine());
            int left = 0;
            for (int i = w - 1; i > 1; --i)
            {
                left++;
                if (left % 2 == 0 && i % 2 == 0)
                    return "YES";
            }
            return "NO";
        }
    }
}
