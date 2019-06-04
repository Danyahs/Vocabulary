using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Vocabulary
{
    class Program
    {
        static void Main(string[] args)
        {
            WordsVocabulary dictionary = new WordsVocabulary(@"C:\Ekzam\d.txt");

            dictionary.Show();
        
        }
    }


    public class WordsVocabulary
    {
        public Dictionary<string, int> dictionary = new Dictionary<string, int>();
       
        public string filename { get; set; }

        public WordsVocabulary(string path)
        {                
            string text = File.ReadAllText(path, Encoding.Default);
            string[] words = Regex.Split(text, @"(\a\r)?\s+|\W+|\d+");

            filename = path;

            foreach (string word in words)
            {
                List<string> wordsAdd = new List<string>();

                if (word != "" && word != " ")
                {
                    wordsAdd.Add(word);
                }

                foreach (string add in wordsAdd)
                {             
                    if (dictionary.Keys.Contains(add))
                    {
                        dictionary[add]++;
                    }
                    else
                    {
                        dictionary.Add(add, 1);
                    }
                }

            }

        }
        public  Dictionary<string, int> Dict(string path)
        {
            string text = File.ReadAllText(path, Encoding.Default);
            string[] words = Regex.Split(text, @"(\a\r)?\s+|\W+|\d+");

            filename = path;

            foreach (string word in words)
            {
                List<string> wordsAdd = new List<string>();

                if (word != "" && word != " ")
                {
                    wordsAdd.Add(word);
                }

                foreach (string add in wordsAdd)
                {
                    if (dictionary.Keys.Contains(add))
                    {
                        dictionary[add]++;
                    }
                    else
                    {
                        dictionary.Add(add, 1);
                    }
                }

            }
            return dictionary;

        }




        public void Show()
        {
            foreach (string key in dictionary.Keys)
            {
                Console.WriteLine("{0} - {1}", key, dictionary[key]);
            }
        }
    }
}
