using System;
using System.IO.Compression;
using System.IO;

namespace FileCompression
{
    //Zaprojektuj program konsolowy, który umożliwi "pakowanie" plików za pomocą konsoli (możliwość spakowania 1 lub więcej plików do jednego ZIPa),
    //korzystając z gotowej metody kompresji ZIP (lub pokrewnych) https://www.nuget.org/packages/System.IO.Compression.ZipFile

    class Program
    {
        static void Main(string[] args)
        {
            const string compressionMode1 = "compress";
            const string compressionMode2 = "decompress";

            if (args.Length > 2 && (args[0] == compressionMode1 || args[0] == compressionMode2))
            {
                switch (args[0])
                {
                    case compressionMode1:
                        for (int i = 2; i < args.Length; i++)
                        {
                            if (File.Exists(args[i]))
                            {
                                Compress(args[1], args[i]);
                            }
                            else
                            {
                                Console.WriteLine($"File \"{args[i]}\" not found.");
                            }
                        }
                        break;

                    case compressionMode2:
                        if (File.Exists(args[1]))
                        {
                            Decompress(args[1], args[2]);
                        }
                        else
                        {
                            Console.WriteLine($"Archive \"{args[1]}\" not found.");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Write: \"compress\" or \"decompress\", the archive's path and files to compresion or where to extract");
            }
        }

        public static void Compress(string archivePath, string fileToCompress)
        {
            using (ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Update))
            {
                archive.CreateEntryFromFile(fileToCompress, Path.GetFileName(fileToCompress));
            }
        }

        public static void Decompress(string archivePath, string extractionPath)
        {
            if (!Directory.Exists(extractionPath))
            {
                Directory.CreateDirectory(extractionPath);
            }

            using (ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Read))
            {
                archive.ExtractToDirectory(extractionPath);
            }
        }
    }
}
