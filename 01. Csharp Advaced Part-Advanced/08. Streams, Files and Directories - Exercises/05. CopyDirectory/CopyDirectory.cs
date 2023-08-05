namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            string[] dir = Directory.GetDirectories(inputPath);
            foreach (string dirName in dir)
            {
                DirectoryInfo inputPathInfo = new DirectoryInfo(inputPath);
                string curentPath = dirName;
                string name = "\\" + inputPathInfo.Name;
                curentPath = curentPath.Replace(name, string.Empty);
                Directory.Move(dirName, curentPath);
            }
            Directory.Delete(outputPath, true);
            Directory.Move(inputPath, outputPath);

        }
    }
}
