
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Vocabulary
{
    [TestFixture]
    class ClassTest
    {
        [Test]
        public void IsStartFileEmpty()
        {
            WordsVocabulary dictionary = new WordsVocabulary(@"C:\Ekzam\d.txt");
            string[] text = File.ReadAllLines(dictionary.filename);
            if (text.Count() < 0)
                Assert.Fail("Start file is empty!");
        }
        [Test]
        public void IsStartFileTxt()
        {
            WordsVocabulary dictionary = new WordsVocabulary(@"C:\Ekzam\d.txt");
            FileInfo fi = new FileInfo(dictionary.filename);
            if (fi.Extension != ".txt")
                Assert.Fail("Start file is not .txt!");
        }
        [Test]
        public void IsStartFileExist()
        {
            WordsVocabulary dictionary = new WordsVocabulary(@"C:\Ekzam\d.txt");
            if (!File.Exists(dictionary.filename))
                Assert.Fail("Start file doesnt exist!");
        }

        [Test]
        public void IsWordCorrectTest()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            WordsVocabulary vocab = new WordsVocabulary(@"C:\Ekzam\d.txt");


            string text = File.ReadAllText(vocab.filename, Encoding.Default);
            string[] words = Regex.Split(text, @"(\a\r)?\s+|\W+|\d+");

            //filename = path;

            foreach (string word in words)
            {            
                List<string> wordsAdd = new List<string>();

                if (word != "" && word != " ")
                {
                    wordsAdd.Add(word);
                }
                              
                foreach (string add in wordsAdd)
                {
                    for (int i = 0; i < add.Length; i++)
                    {
                        if (add[i] == '.' || add[i] == ',' || add[i] == '-' || add[i] == ':')
                            Assert.Fail("Word is not correct!");
                        else
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
        }

        [Test]
        public void IsVocabRight()
        {
            WordsVocabulary vocab = new WordsVocabulary(@"C:\Ekzam\d.txt");

            Dictionary<string, int> dict = vocab.Dict(@"C:\Ekzam\test.txt");

            Dictionary<string, int> test = new Dictionary<string, int>();

            test.Add("fter", 1);
            test.Add("school", 1);
            test.Add("took", 1);
            test.Add("Kamal", 1);
            test.Add("the", 2);
            test.Add("girls", 1);
            test.Add("to", 1);

            if (dict.Count != test.Count)
                Assert.Fail("Размеры словарей не совпадают");

        }

    }
}
       
