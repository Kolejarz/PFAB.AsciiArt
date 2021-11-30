using System;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.PixelFormats;

namespace PFAB.AsciiArt.Runner.Printers
{
    public class ConsoleColorPrinter : ConsolePrinter
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(IntPtr handle, out int mode);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int handle);

        public ConsoleColorPrinter()
        {
            var handle = GetStdHandle(-11);
            GetConsoleMode(handle, out var mode);
            SetConsoleMode(handle, mode | 0x4);
        }

        public override void PrintAsciiPixel(AsciiPixel pixel)
        {
            var color = pixel.ForegroundColor.ToPixel<Argb32>();
            
            Console.Write($"\x1b[38;2;{color.R};{color.G};{color.B}m");
            PrintCharacter(pixel.Character);
        }
    }
}
