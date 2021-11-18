namespace PFAB.AsciiArt.Runner.BrightnessCalculator
{
    public class LuminosityBrightnessCalculationStrategy : IBrightnessCalculationStrategy
    {
        public byte GetBrightness(byte r, byte g, byte b)
        {
            return (byte)(0.21 * r + 0.72 * g + 0.07 * b);
        }
    }
}
