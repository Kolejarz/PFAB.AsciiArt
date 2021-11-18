using System;
using System.Linq;

namespace PFAB.AsciiArt.Runner.BrightnessCalculator
{
    public class LightnessBrightnessCalculationStrategy : IBrightnessCalculationStrategy
    {
        public byte GetBrightness(byte r, byte g, byte b)
        {
            var bytes = new[] { r, g, b };
            return (byte)((bytes.Max() + bytes.Min()) / 2);
        }
    }
}
