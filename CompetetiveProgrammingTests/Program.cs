using CompetetiveProgrammingTests.Base;
using CompetetiveProgrammingTests.ProblemSolution;
using CompetetiveProgrammingTests.ProblemSolution.ProblemSolvers.CriaScript;
using System;
using System.Collections.Generic;

namespace CompetetiveProgrammingTests
{
    public static class Program
    {
        private static readonly List<ISolveProblem> problemSolvers = new List<ISolveProblem>();

        public static void Main(string[] args)
        {
            problemSolvers.AddRange(new ISolveProblem[]
            {
                new WatermelonSolver(),
                new WayTooLongWordsSolver(),
                new ATeamSolver(),
                new NextRound(),
                new NumberToSortedList(),
            });

            //problemSolvers.LastOrDefault().Execute();

            Console.WriteLine(new NumberToSortedList().Execute());
            Console.ReadKey();
        }
    }
}