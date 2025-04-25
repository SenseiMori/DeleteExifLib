using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Text;

namespace ExifDeleteLib
{
    public class ZipCreator
    {
        public void CreateZip(string[] inputFiles, string newZipName, string resultDirectory)
        {
            {
                string zipPath = Path.Combine(resultDirectory, newZipName);
                using var outStream = new FileStream(zipPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, 4096, true);
                using var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true);
                foreach (string fileName in inputFiles)
                {
                    using (var inputStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
                    {
                        ZipArchiveEntry fileEntry = archive.CreateEntry(Path.GetFileName(fileName));
                        using var entryStream = fileEntry.Open();
                        inputStream.CopyTo(entryStream);

                    }
                }
            }
        }
    }
}
