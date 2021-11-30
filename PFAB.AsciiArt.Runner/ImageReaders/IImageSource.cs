using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PFAB.AsciiArt.Runner.ImageReaders
{
    public interface IImageSource
    {
        Image<Argb32> GetImage();
    }
}
