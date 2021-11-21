using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFAB.AsciiArt.Runner.Printers
{
    public interface IPrinter
    {
        void PrintAsciiPixel(AsciiPixel pixel);

        void NewLine();
    }
}
