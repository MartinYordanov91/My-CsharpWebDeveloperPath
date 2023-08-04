using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal;

public class DirectoryTraversal
{
    static void Main()
    {
        string path = Console.ReadLine();
        string reportFileName = @"\report.txt";

        string reportContent = TraverseDirectory(path);
        Console.WriteLine(reportContent);

        WriteReportToDesktop(reportContent, reportFileName);
    }

    public static string TraverseDirectory(string inputFolderPath)
    {
        StringBuilder stringBuilder = new StringBuilder();
        SortedDictionary<string, Dictionary<string, double>> info = new();
        string[] files = Directory.GetFiles(inputFolderPath);
        foreach (var item in files)
        {
            FileInfo curentFile = new(item);
            string extension = curentFile.Extension;
            string name = curentFile.Name;
            double kb = curentFile.Length;
            if (info.ContainsKey(extension) == false)
            {
                info[extension] = new Dictionary<string, double>();
            }
            info[extension].Add(name, kb);
        }
        foreach (var item in info.OrderByDescending(ex => ex.Value.Count()))
        {
            stringBuilder.AppendLine($"{item.Key}");
            foreach (var i in item.Value.OrderBy(c => c.Value))
            {
                stringBuilder.AppendLine($"--{i.Key} - {(i.Value / 1024):f3}kb");
            }
        }
        
        return stringBuilder.ToString();
    }

    public static void WriteReportToDesktop(string textContent, string reportFileName)
    {
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
        File.WriteAllText(filePath, textContent);
    }
}
