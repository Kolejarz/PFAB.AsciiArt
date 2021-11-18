using SixLabors.ImageSharp.PixelFormats;

namespace PFAB.AsciiArt.Runner
{
    public static class PixelConverter
    {
        private const string BrightnessMap = "`^\",:;Il!i~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";

        public static char GetAscii(Argb32 pixel)
        {
            var brightness = BrightnessCalculator.GetBrightness(pixel);
            return BrightnessMap[brightness % BrightnessMap.Length];
        }
    }
}
