namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";
            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }
        public static void SplitBinaryFile(string sourceFilePath, string
       partOneFilePath, string partTwoFilePath)
        {
            using FileStream stream = new FileStream(sourceFilePath, FileMode.Open);
            byte[] bytesTextSize = new byte[(int)Math.Ceiling(stream.Length / 2.0)];
            using FileStream one = new FileStream(partOneFilePath, FileMode.OpenOrCreate);
            stream.Read(bytesTextSize);
            one.Write(bytesTextSize);
            using FileStream two = new FileStream(partTwoFilePath, FileMode.OpenOrCreate);
            stream.Read(bytesTextSize);
            two.Write(bytesTextSize);
        }
        public static void MergeBinaryFiles(string partOneFilePath, string
       partTwoFilePath, string joinedFilePath)
        {
            using FileStream one = new FileStream(partOneFilePath, FileMode.Open);
            using FileStream two = new FileStream(partTwoFilePath, FileMode.Open);
            byte[] concanates = new byte[one.Length];
            using FileStream concanate = new FileStream(joinedFilePath, FileMode.OpenOrCreate);
            one.Read(concanates);
            concanate.Write(concanates);
            two.Read(concanates);
            concanate.Write(concanates);
        }
    }
}