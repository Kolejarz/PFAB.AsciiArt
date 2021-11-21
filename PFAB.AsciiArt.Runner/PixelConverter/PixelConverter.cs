using System;
using System.Linq;
using PFAB.AsciiArt.Runner.BrightnessCalculator;
using SixLabors.ImageSharp.PixelFormats;

namespace PFAB.AsciiArt.Runner.PixelConverter
{
    public class PixelConverter
    {
        private const string BrightnessMap = "`^\",:;Il!i~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";
        private readonly BrightnessCalculator.BrightnessCalculator _brightnessCalculator;
        private readonly bool _invertedMode;

        public PixelConverter(BrightnessCalculationMode brightnessCalculationMode, bool invertedMode = false)
        {
            _brightnessCalculator = brightnessCalculationMode switch
            {
                BrightnessCalculationMode.Average => BrightnessCalculatorFactory.BrightnessCalculator()
                    .WithAverageBrightnessCalculationStrategy(),
                BrightnessCalculationMode.Lightness => BrightnessCalculatorFactory.BrightnessCalculator()
                    .WithLightnessBrightnessCalculationStrategy(),
                BrightnessCalculationMode.Luminosity => BrightnessCalculatorFactory.BrightnessCalculator()
                    .WithLuminosityBrightnessCalculationStrategy(),
                _ => throw new ArgumentOutOfRangeException(nameof(brightnessCalculationMode))
            };
            _invertedMode = invertedMode;
        }

        public AsciiPixel GetAscii(Argb32 pixel)
        {
            var brightness = _brightnessCalculator.GetBrightness(pixel);
            var character =  _invertedMode ? 
                BrightnessMap[brightness % BrightnessMap.Length] :
                BrightnessMap.Reverse().ToArray()[brightness % BrightnessMap.Length];

            return new AsciiPixel { Character = character };
        }
    }
}
