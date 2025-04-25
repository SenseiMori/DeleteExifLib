using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ExifDeleteLib
{
    public class JPGMetadataRemover
    {
        JPGFile JPGFile { get; set; }
        JPGDirectory JPGDirectory { get; set; }

        public void RemoveExifForImage(string [] files)
        {
            foreach (string image in files)
            {
                byte[] clearData = JPGFile.FindMarkers(image);
                string clearImagesDirectory = JPGDirectory.CreateDirectory(image);
                string clearImage = JPGDirectory.CreateFileInNewDirectory(clearImagesDirectory);
                JPGDirectory.WriteDataToNewFile(clearData, clearImage);
            }
        }
    }
}
