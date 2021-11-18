namespace PFAB.AsciiArt.Runner.BrightnessCalculator
{
    public class BrightnessCalculatorFactory
    {
        public static BrightnessCalculatorFactory BrightnessCalculator() => new();

        public BrightnessCalculator WithAverageBrightnessCalculationStrategy() =>
            new(new AverageBrightnessCalculationStrategy());

        public BrightnessCalculator WithLightnessBrightnessCalculationStrategy() =>
            new(new LightnessBrightnessCalculationStrategy());

        public BrightnessCalculator WithLuminosityBrightnessCalculationStrategy() =>
            new(new LuminosityBrightnessCalculationStrategy());
    }
}
