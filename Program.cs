using System.Collections;
using System.Runtime.CompilerServices;
using System.Linq;

namespace MostCommonWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load file from SLN folder:
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Text1.txt");
            string[] lines = File.ReadAllLines(path);
            Console.WriteLine($"Lines loaded, {lines.Length} total");

            // Find words:
            Dictionary<string, uint> words= new();
            foreach( string line in lines )
            {
                string[] lineWords = line.Split(' ');
                foreach (string lineWord in lineWords)
                    if (words.ContainsKey(lineWord))
                        words[lineWord] += 1;
                    else if( lineWord.Length > 1 || ( lineWord.Length == 1 && Char.IsLetter(lineWord, 0) ) )
                        words.Add(lineWord, 1);
            }
            Console.WriteLine($"Found {words.Count} unique words");

            // Sort words:
            var sorted = words.OrderByDescending(x => x.Value).Take(10).ToList();
            foreach (var cell in sorted)
                Console.WriteLine(cell);
        }
    }
}