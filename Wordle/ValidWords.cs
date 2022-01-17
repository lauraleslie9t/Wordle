using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Wordle
{
    public class ValidWords
    {
        public List<string> NonDupeWords;
        

        public ValidWords()
        {
            NonDupeWords = new List<string>();
            string fileName = "validWords.csv";
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            StreamReader wordReader = new StreamReader("validWords.csv");
            string file = wordReader.ReadToEnd();
            string[] wordArray = file.Split(", ");
            foreach (string word in wordArray)
            {
                if (word.Length==5 & !IsDuplicateChar(word) )
                {
                    NonDupeWords.Add(word);
                }
            }
            wordReader.Close();
        }

        private bool IsDuplicateChar(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[i] == word[j] && i != j) 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string GetRandomWord()
        {
            Random rnd = new Random();
            return NonDupeWords[rnd.Next(0, NonDupeWords.Count)];
        }
    }
}
