using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFAB.AsciiArt.Runner.Printers
{
    public class ConsoleMatrixPrinter : ConsolePrinter
    {
        public ConsoleMatrixPrinter()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        public override void PrintAsciiPixel(AsciiPixel pixel)
        {
            PrintCharacter(pixel.Character);
        }
    }
}
