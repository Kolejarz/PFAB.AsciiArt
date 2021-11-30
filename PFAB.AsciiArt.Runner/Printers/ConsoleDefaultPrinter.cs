using System;

namespace PFAB.AsciiArt.Runner.Printers
{
    class ConsoleDefaultPrinter : ConsolePrinter
    {
        public ConsoleDefaultPrinter()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public override void PrintAsciiPixel(AsciiPixel pixel)
        {
            PrintCharacter(pixel.Character);
        }
    }
}
