namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using FileStream filerestream = new FileStream(inputFilePath, FileMode.Open);
            byte[] buffer = new byte[filerestream.Length];
            filerestream.Read(buffer);
            using FileStream copyOfPng = new FileStream(outputFilePath,FileMode.OpenOrCreate);
            copyOfPng.Write(buffer) ;
        }
    }
}
