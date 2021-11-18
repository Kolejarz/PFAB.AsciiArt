using System;
using PFAB.AsciiArt.Runner.BrightnessCalculator;
using SixLabors.ImageSharp.PixelFormats;

namespace PFAB.AsciiArt.Runner.PixelConverter
{
    public static class PixelConverter
    {
        private const string BrightnessMap = "`^\",:;Il!i~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";

        public static char GetAscii(Argb32 pixel, int brightnessCalculationMode)
        {
            var brightnessCalculator = (brightnessCalculationMode % 3) switch
            {
                0 => BrightnessCalculatorFactory.BrightnessCalculator().WithAverageBrightnessCalculationStrategy(),
                1 => BrightnessCalculatorFactory.BrightnessCalculator().WithLightnessBrightnessCalculationStrategy(),
                2 => BrightnessCalculatorFactory.BrightnessCalculator().WithLuminosityBrightnessCalculationStrategy(),
                _ => throw new ArgumentOutOfRangeException(nameof(brightnessCalculationMode))
            };
            
            var brightness = brightnessCalculator.GetBrightness(pixel);
            return BrightnessMap[brightness % BrightnessMap.Length];
        }
    }
}
