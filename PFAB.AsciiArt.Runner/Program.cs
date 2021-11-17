using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
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

            using var image = Image.Load<Argb32>(Path);
            Console.WriteLine($"{image.Width}x{image.Height}");

            image.Mutate(i => i.Resize(0, 128));
            for (var y = 0; y < image.Height; y++)
            {
                Console.Write(y.ToString().PadRight(4));
                foreach(var pixel in image.GetPixelRowSpan(y))
                {
                    Console.Write(pixel);
                }
                Console.WriteLine();
            }
        }
    }
}
