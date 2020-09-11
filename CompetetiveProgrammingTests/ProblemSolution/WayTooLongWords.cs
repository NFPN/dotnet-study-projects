using CompetetiveProgrammingTests.Base;
using System;
using System.Text;

namespace CompetetiveProgrammingTests.ProblemSolution
{
    public class WayTooLongWordsSolver : ISolveProblem
    {
        /// <summary>
        /// https://codeforces.com/problemset/problem/71/A
        /// </summary>
        public WayTooLongWordsSolver() { }

        public string Execute()
        {
            var builder = new StringBuilder();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                if (word.Length > 10)
                    builder.Append(word[0]).Append(word.Length - 2).AppendLine($"{word[word.Length - 1]}");
                else builder.AppendLine(word);
            }
            Console.WriteLine(builder.ToString());
            return builder.ToString();
        }
    }
}
