using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExifDeleteLib
{
     public class JPGDirectory
    {
        public string[] GetImagesFromFolder(string folder)
        {
            string[] images =  Directory.GetFiles(folder, "*.jpg");
            return images;
        }
        public string CreateFileInNewDirectory(string OriginFile, string newDirectory)
        {
               
                string outFileName = Path.GetFileName(OriginFile);
                string outputFilePath = Path.Combine(newDirectory, outFileName);
                using (var outStream = new StreamWriter(File.Create(outputFilePath)))
                return outputFilePath;
        }

        public string CreateDirectory (string originDirectory)
        {
            string dir = Path.GetDirectoryName(originDirectory);
            string newDirectory = Path.Combine(dir, "ClearImages");
            if (!Directory.Exists(newDirectory))
            {
                Directory.CreateDirectory(newDirectory);
            }
            return newDirectory;

        }
       
    }
}
