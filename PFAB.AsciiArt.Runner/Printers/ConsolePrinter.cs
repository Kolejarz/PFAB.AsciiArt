using System;

namespace PFAB.AsciiArt.Runner.Printers
{
    public abstract class ConsolePrinter : IPrinter, IDisposable
    {
        protected ConsolePrinter()
        {
            Console.Clear();
        }

        public abstract void PrintAsciiPixel(AsciiPixel pixel);

        public void NewLine()
        {
            Console.WriteLine();
        }

        public void Dispose()
        {
            Console.ResetColor();
        }

        protected void PrintCharacter(char character)
        {
            Console.Write(new string(character, 2));
        }
    }
}
