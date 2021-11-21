using System;
using PFAB.AsciiArt.Runner.BrightnessCalculator;
using PFAB.AsciiArt.Runner.Printers;
using PFAB.AsciiArt.Runner.PixelConverter;
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

        [Argument('m', "matrixMode", "")]
        private static bool MatrixMode { get; set; }

        static void Main(string[] args)
        {
            Arguments.Populate();
            MatrixMode = true;

            using var image = Image.Load<Argb32>(Path);
            image.Mutate(i => i.Resize(0, 80));

            var counter = 0;
            do
            {
                using var printer = MatrixMode ? new ConsoleMatrixPrinter() : new ConsolePrinter();
                var converter = new PixelConverter.PixelConverter((BrightnessCalculationMode)(counter % 3), counter % 6 > 2);

                for (var y = 0; y < image.Height; y++)
                {
                    foreach (var pixel in image.GetPixelRowSpan(y))
                    {
                        var c = converter.GetAscii(pixel);
                        printer.PrintAsciiPixel(c);
                    }

                    printer.NewLine();
                }

                counter++;
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
