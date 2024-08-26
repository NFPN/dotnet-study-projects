using CompetetiveProgrammingTests.Base;
using System;
using System.Collections.Generic;

namespace CompetetiveProgrammingTests.ProblemSolution.ProblemSolvers.CriaScript
{
    public class NumberToSortedList : ISolveProblem
    {
        public string Execute()
        {
            var randNumber = new Random().Next();
            var nums = new List<int>();

            Console.WriteLine(randNumber);

            while (randNumber > 0)
            {
                nums.Add(randNumber % 10);
                randNumber /= 10;
            }

            nums.Sort();

            return string.Join(",", nums);
        }
    }
}
