using SixLabors.ImageSharp.PixelFormats;

namespace PFAB.AsciiArt.Runner.BrightnessCalculator
{
    public class BrightnessCalculator
    {
        private readonly IBrightnessCalculationStrategy _brightnessCalculationStrategy;

        public BrightnessCalculator(IBrightnessCalculationStrategy brightnessCalculationStrategy)
        {
            _brightnessCalculationStrategy = brightnessCalculationStrategy;
        }

        public int GetBrightness(Argb32 pixel)
        {
            return _brightnessCalculationStrategy.GetBrightness(pixel.R, pixel.G, pixel.B);
        }
    }
}
