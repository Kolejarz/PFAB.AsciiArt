using System.Drawing.Imaging;
using System.IO;
using Emgu.CV;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PFAB.AsciiArt.Runner.ImageReaders
{
    public class WebcamCapture : IImageSource
    {
        public Image<Argb32> GetImage()
        {
            var capture = new VideoCapture();
            var frame = capture.QueryFrame().ToBitmap();

            using var memoryStream = new MemoryStream();
            frame.Save(memoryStream, ImageFormat.Png);
            memoryStream.Seek(0, SeekOrigin.Begin);
            capture.Dispose();

            return Image.Load<Argb32>(memoryStream);
        }
    }
}
