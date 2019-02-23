using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTrav
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> dict = new Dictionary<string, Dictionary<string, decimal>>();
            string[] files = Directory.GetFiles(@"..\..\..\..\..\04. Streams-Exercise", "*.*", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                var currentFile = File.Open(file, FileMode.Open);
                var fullName = Path.GetFileName(file);
                var extension = Path.GetExtension(file);
                var fileSize = Decimal.Divide(currentFile.Length, 1024);

                if (!dict.ContainsKey(extension))
                {
                    dict.Add(extension, new Dictionary<string, decimal>());
                }

                if (!dict[extension].ContainsKey(fullName))
                {
                    dict[extension].Add(fullName, fileSize);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\report.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var extension in dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    writer.WriteLine($"{extension.Key}");
                    foreach (var file in extension.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"{file.Key} - {file.Value:F2}kb");
                    }
                }
            }

        }
    }
}
