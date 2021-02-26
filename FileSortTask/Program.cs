using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSortTask {
    class Program {
        static void Main(string[] args) {
            string pathReader = "TextFiles/text2.txt";
            string pathWriter = "TextFiles/textWriter.txt";
            try {
                using (StreamWriter sw = new StreamWriter(pathWriter)) {
                    StreamReader sr = new StreamReader(pathReader);
                    string line;
                    while((line = sr.ReadLine()) != null) {
                        var words = line.Split(' ', '-', ',', ':', '.', '"', '\'', '!', '?', '–', '(', ')', ']', '[')
                            .Where(q => !string.IsNullOrEmpty(q));
                        var result = new Dictionary<string, int>();
                        var uniqWrds = words.Select(q => q.ToLower().Trim()).Distinct();
                        foreach (var word in uniqWrds) {
                            result.Add(word, words.Count());
                        }
                        result = result.OrderByDescending(q => q.Value)
                            .ToList()
                            .ToDictionary(key => key.Key, value => value.Value);
                        foreach (var word in result) {
                            string writer = $"Word: {word.Key} Count: {word.Value}";
                            sw.WriteLine(writer);
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
