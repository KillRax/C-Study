using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше предложение:");
            string text = Console.ReadLine();

            List<string> words = SplitTextByWords(text);

            Console.WriteLine("\nРазделенный текст:");
            OutputWords(words);

            string reversedText = ReverseText(text);
            Console.WriteLine("\nПеревернутый текст:");
            Console.WriteLine(reversedText);
        }

        static List<string> SplitTextByWords(string text)
        {
            List<string> words = new List<string>();
            int indexOfStart = 0;
            int indexOfEnd = text.IndexOf(" ");
            
            while ((text.Length > 0) && (indexOfEnd > 0))
            {
                words.Add(text.Substring(indexOfStart, indexOfEnd));
                text = text.Remove(indexOfStart, indexOfEnd + 1);
                indexOfEnd = text.IndexOf(" ");
            }
            words.Add(text);
            return words;
        }

        static void OutputWords(List<string> words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        static string ReverseText(string text)
        {
            List<string> words = SplitTextByWords(text);
            string reversedText = "";

            foreach (string word in words) 
            {
                reversedText = word+ " " + reversedText;
            }
            reversedText = reversedText.Trim();
            return reversedText;
        }
    }
}
