namespace PFAB.AsciiArt.Runner.BrightnessCalculator
{
    public interface IBrightnessCalculationStrategy
    {
        byte GetBrightness(byte r, byte g, byte b);
    }
}
