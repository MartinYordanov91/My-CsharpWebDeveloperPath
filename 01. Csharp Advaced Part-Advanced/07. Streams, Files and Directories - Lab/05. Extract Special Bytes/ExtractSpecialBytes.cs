namespace ExtractSpecialBytes
{
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";
            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);

        }
        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string
       bytesFilePath, string outputPath)
        {
            List<byte> bytes = new List<byte>();
            using StreamReader reader = new StreamReader(bytesFilePath);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                bytes.Add(byte.Parse(line));
            }

            List<byte> picPerByte = new List<byte>();
            using FileStream binaryBytes = new FileStream(binaryFilePath, FileMode.Open);
            byte[] buffer = new byte[binaryBytes.Length];
            binaryBytes.Read(buffer);

            for (int i = 0; i < buffer.Length; i++)
            {
                byte curentByte = buffer[i];
                if (bytes.Contains(curentByte))
                    picPerByte.Add(curentByte);
            }

            using FileStream outputFile = new FileStream(outputPath, FileMode.OpenOrCreate);
            outputFile.Write(picPerByte.ToArray());
        }
    }
}
