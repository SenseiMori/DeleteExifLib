using System.Buffers;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Principal;

namespace ExifRemoveConsole
{

    /*
     * Максимально оптимизировать. MemoryStream?
     */

     class Start
    {
        private JPGFile _JPGFile;
        private JPGDirectory _JPGDirectory;
        public Start(JPGFile JPGFile, JPGDirectory JPGDirectory)
        {
            _JPGFile = JPGFile;
            _JPGDirectory = JPGDirectory;
        }
        public static async Task Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            JPGFile jpgFile = new JPGFile();
            JPGDirectory jpgDirectory = new JPGDirectory();
            Start start = new Start(jpgFile, jpgDirectory);
            string[] PathToNewImages;
            
            string name = "C:\\Users\\1311971\\Desktop\\Ensigame\\Тестовые изображения для RemoveExifAPI\\набор1\\1.jpg";
            string someImages = "C:\\Users\\1311971\\Desktop\\Ensigame\\Тестовые изображения для RemoveExifAPI\\набор1";
            

            string[] oldImages = start._JPGDirectory.GetImagesFromFolder(someImages);
            PathToNewImages = await start.MultipleDelete(oldImages);
            await jpgFile.CreateZip(PathToNewImages, "result.zip", someImages);
            //start.SingleDelete(name);   
        }


        public async Task <string[]> MultipleDelete(string[] images)
        {
            List <string> imagesList = new List <string>();
            string pathToFile;
            foreach (string image in images) 
            {
            
                byte[] data =  await _JPGFile.FindMarkers(image);
                string newImage = await _JPGDirectory.CreateFileInNewDirectory(image);
                pathToFile = _JPGDirectory.WriteDataToNewFile(data, newImage);
                imagesList.Add(pathToFile); 
            }
            return imagesList.ToArray();
        }
       
        public async Task SingleDelete(string file)
        {
            byte[] data = await _JPGFile.FindMarkers(file);
            string newImage = await _JPGDirectory.CreateFileInNewDirectory(file);
            _JPGDirectory.WriteDataToNewFile(data, newImage);
        }
        
        
        
        //=> (ushort)((secondByte << 8) | firstByte);

        //Console.WriteLine($"{Convert.ToString(result, toBase: 16)}\n");
        //byte flag = 0b_1111_1111;
        //byte mask = 0b_0000_1000;
        //flag = (byte)~mask;
        //Console.WriteLine(Convert.ToString(flag, toBase: 2));
        
              
    }
}
