namespace PFAB.AsciiArt.Runner.BrightnessCalculator
{
    public class AverageBrightnessCalculationStrategy : IBrightnessCalculationStrategy
    {
        public byte GetBrightness(byte r, byte g, byte b)
        {
            return (byte) ((r + g + b) / 3);
        }
    }
}
