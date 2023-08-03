using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";
            CalculateWordCounts(wordPath, textPath, outputPath);
        }
        public static void CalculateWordCounts(string wordsFilePath, string
       textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordsCount = new();
            using StreamReader readerWords = new StreamReader(wordsFilePath);
            while (!readerWords.EndOfStream)
            {
                string[] words = readerWords.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    if (wordsCount.ContainsKey(word.Trim()) == false)
                    {
                        wordsCount[word.Trim()] = 0;
                    }
                }
            }

            using StreamReader text = new StreamReader(textFilePath);
            while (!text.EndOfStream)
            {
                string textLine = text.ReadLine().ToLower();
                foreach (var dic in wordsCount)
                {
                    Regex reg = new(@"\b" + $"{dic.Key}" + @"\b");
                    MatchCollection matches = reg.Matches(textLine);
                    foreach (Match match in matches)
                    {
                        wordsCount[dic.Key]++;
                    }
                }

            }

            using StreamWriter writerWords = new StreamWriter(outputFilePath);
            foreach (var item in wordsCount.OrderByDescending(x => x.Value))
            {
                writerWords.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}