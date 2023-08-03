using System.Security.Cryptography;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";
            GetFolderSize(folderPath, outputPath);
        }
        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            
            double kilomytes = GetSize(folderPath);
            using StreamWriter writer = new StreamWriter(outputFilePath);
            writer.Write($"{kilomytes / 1024} KB");
        }
        public static double GetSize(string folderPath)
        {
            

            string[] filesPath = Directory.GetFiles(folderPath);
            double size = 0;

            foreach (string file in filesPath)
            {
                FileInfo info = new FileInfo(file);
                size += info.Length;
            }

            foreach (string dirPath in Directory.GetDirectories(folderPath))
            {
                size += GetSize(dirPath);
            }
            return size;
        }
    }
}
