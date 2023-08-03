namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";
            MergeTextFiles(firstInputFilePath, secondInputFilePath,
           outputFilePath);
        }
        public static void MergeTextFiles(string firstInputFilePath, string
       secondInputFilePath, string outputFilePath)
        {
            using StreamReader srFirst = new StreamReader(firstInputFilePath);
            using StreamReader srSecond = new StreamReader(secondInputFilePath);
            using StreamWriter output = new StreamWriter(outputFilePath);
            while (!srFirst.EndOfStream || !srSecond.EndOfStream)
            {
                if (!srFirst.EndOfStream)
                {
                    string text = srFirst.ReadLine();
                    output.WriteLine(text);
                }

                if (!srSecond.EndOfStream)
                {
                    string text = srSecond.ReadLine();
                    output.WriteLine(text);
                }
            }
        }
    }
}
