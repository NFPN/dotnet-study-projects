using System;
using System.IO;

namespace PngConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dir = @"C:\TestFiles";// Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var files = new DirectoryInfo(dir).GetFiles();

            foreach (var file in files)
            {
                Console.WriteLine($"Converting - {file}");

                file.MoveTo(Path.ChangeExtension(file.FullName, "gif"));
            }

            Console.WriteLine($"Converting finished...");
        }
    }
}
