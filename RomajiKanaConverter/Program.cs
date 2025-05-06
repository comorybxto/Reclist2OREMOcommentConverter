using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomajiKanaConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Title("JPN Reclist to OREMO-comment Converter v1.0");
            Console.WriteLine("\n1) Kana reclist -> Romaji comment");
            Console.WriteLine("\n2) Romaji reclist -> Kana comment");

            string option = string.Empty;
            do
            {
                Console.Write("\nEnter option: ");
                option = Console.ReadLine();
                if (option == "1" || option == "2")
                    break;
                Console.WriteLine("Invalid option. Please enter 1 or 2.");
            } while (true);

            Console.WriteLine();

            var inputTxtName = string.Empty;
            do
            {
                Console.Write("Enter a valid name for the txt file (without extension): ");
                inputTxtName = Console.ReadLine() + ".txt";
            } while (!File.Exists(inputTxtName));

            string[] lines = File.ReadAllLines(inputTxtName, Encoding.GetEncoding(932));
            var output = new List<string>();

            OremoConversion(lines, output, option);
        }

        static void OremoConversion(string[] lines,List<string> output, string option)
        {
            foreach (string line in lines)
            {
                var convertedLine = option.Equals("1") ? Kana2Romaji.Convert(line) : Romaji2Kana.Convert(line);

                if (convertedLine == "")
                    continue;
                else if (line != convertedLine)
                    output.Add(line + "\t" + convertedLine.TrimStart('_'));
                else
                {
                    output.Add('*' + line + '*');
                }
            }

            try
            {
                File.WriteAllText("OREMO-comment.txt", string.Join("\n", output), Encoding.GetEncoding(932)); 
                Console.WriteLine("OREMO-comment.txt file was successfully created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void Title(string title)
        {
            string separator = new string('-', title.Length);
            Console.WriteLine(separator);
            Console.WriteLine(title.PadLeft(title.Length));
            Console.WriteLine(separator);
        }
    }
}
