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
        public string CreateFileInNewDirectory(string PathToOriginJpgFile)
        {
                string dir = Path.GetDirectoryName(PathToOriginJpgFile);
                string newFolder = Path.Combine(dir, "ClearImages");
                Directory.CreateDirectory(newFolder);
                string outFileName = Path.GetFileName(PathToOriginJpgFile);
                string outputFilePath = Path.Combine(newFolder, outFileName);
                using (var outStream = new StreamWriter(File.Create(outputFilePath)))
                return outputFilePath;
        }
        public string WriteDataToNewFile (byte[] data, string pathToNewFile)
        {
            using (var fileStream = new FileStream(pathToNewFile, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                fileStream.Write(data, 0, 2);
            }
            return pathToNewFile;
        }
    }
}
