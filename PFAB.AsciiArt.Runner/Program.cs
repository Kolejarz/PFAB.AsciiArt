using System;
using System.Linq;
using PFAB.AsciiArt.Runner.ImageReaders;
using PFAB.AsciiArt.Runner.Printers;
using SixLabors.ImageSharp.Processing;
using Utility.CommandLine;
using static System.String;

namespace PFAB.AsciiArt.Runner
{
    class Program
    {
        [Argument('s', "source", "Source of image to be processed. [file, webcam]")]
        private static string Source { get; set; }

        [Argument('b', "brightnessCalculation", "Brightness calculation mode. [average, lightness, luminosity]")]
        private static string BrightnessCalculationMode { get; set; }

        [Argument('c', "colorMode", "Color mode. [default, matrix, color]")]
        private static string ColorMode { get; set; }

        [Argument('i', "invertedMode", "Inverted brightness calculation.")]
        private static bool InvertedMode { get; set; }

        [Argument('p', "path", "Path to the image that would be processed to ASCII")]
        private static string Path { get; set; }

        [Argument('h', "help", "Display help message")]
        private static bool Help { get; set; }

        static void Main(string[] args)
        {
            Arguments.Populate();

            if (Help)
            {
                ShowHelp();
                return;
            }

            BrightnessCalculationMode =
                IsNullOrWhiteSpace(BrightnessCalculationMode) ? "average" : BrightnessCalculationMode;
            ColorMode = IsNullOrWhiteSpace(ColorMode) ? "default" : ColorMode;

            var errorMessage = Validate();

            if (!IsNullOrWhiteSpace(errorMessage))
            {
                WriteError(errorMessage);
                ShowHelp();
                return;
            }

            IImageSource imageSource = Source == "file" ? new FileReader(Path) : new WebcamCapture();
            using var image = imageSource.GetImage();
            image.Mutate(i => i.Resize(0, 64));

            using ConsolePrinter printer = ColorMode switch
            {
                "matrix" => new ConsoleMatrixPrinter(),
                "color" => new ConsoleColorPrinter(),
                _ => new ConsoleDefaultPrinter()
            };

            var brightnessCalculationMode = BrightnessCalculationMode switch
            {
                "lightness" => BrightnessCalculator.BrightnessCalculationMode.Lightness,
                "luminosity" => BrightnessCalculator.BrightnessCalculationMode.Luminosity,
                _ => BrightnessCalculator.BrightnessCalculationMode.Average
            };

            var converter = new PixelConverter.PixelConverter(brightnessCalculationMode, InvertedMode);
            for (var y = 0; y < image.Height; y++)
            {
                foreach (var pixel in image.GetPixelRowSpan(y))
                {
                    var c = converter.GetAscii(pixel);
                    (printer as IPrinter).PrintAsciiPixel(c);
                }

                (printer as IPrinter).NewLine();
            }
        }

        private static void ShowHelp()
        {
            var helpAttributes = Arguments.GetArgumentInfo().ToList();
            var spaceCount = helpAttributes.Max(x => x.LongName.Length);

            Console.WriteLine($"Short\tLong{new string(' ', spaceCount - 8)}\tFunction");
            Console.WriteLine($"-----\t----{new string(' ', spaceCount - 8)}\t--------");

            foreach (var item in helpAttributes)
            {
                var result = item.ShortName + "\t" + item.LongName +
                             new string(' ', spaceCount - item.LongName.Length) + "\t" + item.HelpText;
                Console.WriteLine(result);
            }
        }

        private static void WriteError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }

        private static string Validate()
        {
            if (IsNullOrWhiteSpace(Source))
            {
                return $"Parameter '{nameof(Source)}' is mandatory.";
            }

            if (IsNullOrWhiteSpace(Path) && Source == "file")
            {
                return $"Parameter '{nameof(Path)}' is mandatory when 'file' is selected for source";
            }

            if (!new[] { "file", "webcam" }.Contains(Source))
            {
                return $"{Source} is not valid value for parameter {nameof(Source)}";
            }

            if (!new[] { "average", "lightness", "luminosity" }.Contains(BrightnessCalculationMode))
            {
                return
                    $"{BrightnessCalculationMode} is not valid value for parameter {nameof(BrightnessCalculationMode)}";
            }

            if (!new[] { "default", "matrix", "color" }.Contains(ColorMode))
            {
                return $"{ColorMode} is not valid value for parameter {nameof(ColorMode)}";
            }

            return Empty;
        }
    }
}
