using System;

namespace PFAB.AsciiArt.Runner.Printers
{
    public class ConsolePrinter : IPrinter, IDisposable
    {
        public ConsolePrinter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PrintAsciiPixel(AsciiPixel pixel)
        {
            Console.Write(new string(pixel.Character, 3));
        }

        public void NewLine()
        {
            Console.WriteLine();
        }

        public void Dispose()
        {
            Console.ResetColor();
        }
    }
}
