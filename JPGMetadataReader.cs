using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using ExifDeleteLib.Core;
using System.Linq;

namespace ExifDeleteLib
{
    public class JPGMetadataReader
    {
        JPGFile JPGFile { get; set; }

        public Dictionary <string, byte[]> newImages= new Dictionary<string, byte[]>();
        public JPGMetadataReader()
        {
            JPGFile = new JPGFile(); 
        }
        public void ReadExifFromImage(string [] files)
        {
            List<byte[]> data = new List<byte[]>();

            foreach (string image in files)
            {
                byte[] clearData = JPGFile.FindMarkers(image);
                data.Add(clearData); 
                newImages.Add(image,clearData);
            }    

        }
    }
}
