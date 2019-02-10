using System;
using System.IO;
using System.Linq;
using System.Text;
using SharpKml.Dom;
using SharpKml.Engine;

namespace Console
{
    class Program
    {

        static void Main(string[] args)
        {
            // First get the Kml into a KmlFile object
            var file = KmlFile.Load(File.Open(@"C:\Users\HP\Desktop\export.kml", FileMode.Open));

            Kml kml = file.Root as Kml;
            if (kml != null)
            {
                foreach (var way in kml.Flatten().OfType<LineString>())
                {
                    foreach (var wayCoordinate in way.Coordinates)
                    {
                        System.Console.WriteLine(way.Coordinates);
                    }
                }
            }


            System.Console.ReadKey();
        }
    }
}
