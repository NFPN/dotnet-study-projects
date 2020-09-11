using CompetetiveProgrammingTests.Base;
using CompetetiveProgrammingTests.ProblemSolution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompetetiveProgrammingTests
{
    public class Program
    {
        private static readonly List<ISolveProblem> problemSolvers = new List<ISolveProblem>();

        public static void Main(string[] args)
        {
            problemSolvers.AddRange(new ISolveProblem[]
            {
                new WatermelonSolver(),
                new WayTooLongWordsSolver(),
                new ATeamSolver(),
            });

            problemSolvers.LastOrDefault().Execute();
            Console.ReadKey();
        }
    }
}