using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ExifDeleteLib
{
    public class JPGMetadataRemover
    {
        JPGFile JPGFile { get; set; }
        JPGDirectory JPGDirectory { get; set; }

        public JPGMetadataRemover()
        {
            JPGFile = new JPGFile();
            JPGDirectory = new JPGDirectory();  
        }
        public void RemoveExifForImage(string [] files)
        {
            List <string> newImages = new List<string>();
            Stopwatch sw = Stopwatch.StartNew();
            foreach (string image in files)
            {
                byte[] clearData = JPGFile.FindMarkers(image);
                string clearImagesDirectory = JPGDirectory.CreateDirectory(image);
                string clearImage = JPGDirectory.CreateFileInNewDirectory(image, clearImagesDirectory);
                JPGFile.WriteDataToNewFile(clearData, clearImage);

            }
        }
    }
}
