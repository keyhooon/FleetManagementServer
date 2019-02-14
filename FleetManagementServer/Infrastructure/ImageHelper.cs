using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace FleetManagementServer.Infrastructure
{
    public static class ImageHelper
    {
        public static byte[] FromFileToByte(string path)
        {
            byte[] binary;
            using (var memoryStream = new MemoryStream())
            {
                using (var image = Image.Load(path))
                {
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save(memoryStream, PngFormat.Instance); // Automatic encoder selected based on extension.
                }
                binary = memoryStream.GetBuffer();
            }
            return binary;
        }
    }
}
