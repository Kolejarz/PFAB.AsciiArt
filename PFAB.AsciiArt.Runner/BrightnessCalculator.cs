using SixLabors.ImageSharp.PixelFormats;

namespace PFAB.AsciiArt.Runner
{
    public static class BrightnessCalculator
    {
        public static int GetBrightness(Argb32 pixel)
        {
            return (int)(0.21 * pixel.R + 0.72 * pixel.G + 0.07 * pixel.B);
        }
    }
}
