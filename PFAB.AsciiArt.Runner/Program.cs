using System;
using System.IO;
using Utility.CommandLine;

namespace PFAB.AsciiArt.Runner
{
    class Program
    {
        [Argument('p', "path", "Path to the image that would be processed to ASCII")]
        private static string Path { get; set; }

        static void Main(string[] args)
        {
            Arguments.Populate();

            using var file = File.Open(Path, FileMode.Open);
            Console.WriteLine(file.Length);
        }
    }
}
