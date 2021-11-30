using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace PFAB.AsciiArt.Runner.ImageReaders
{
    public class FileReader : IImageSource
    {
        private readonly string _path;

        public FileReader(string path)
        {
            _path = path;
        }

        public Image<Argb32> GetImage()
        {
            var image = Image.Load<Argb32>(_path);
            image.Mutate(i => i.OilPaint());
            return image;
        }
    }
}
