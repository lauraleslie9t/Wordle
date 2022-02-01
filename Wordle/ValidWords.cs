using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Wordle
{
    public class ValidWords
    {
        public List<string> WordsToGuess { get; set; }
        public List<string> ValidWordsToGuess { get; set; }
        

        public ValidWords()
        {
            WordsToGuess = new List<string>();
            StreamReader validWordReader = new StreamReader("../../../Words/WordsToGuess.csv");
            string file = validWordReader.ReadToEnd();
            string[] wordArray = file.Split("\r\n");
            foreach (string word in wordArray)
            {
                WordsToGuess.Add(word.ToUpper());
            }
            validWordReader.Close();


            ValidWordsToGuess = new List<string>();
            StreamReader validGuessReader = new StreamReader("../../../Words/GuessList.csv");
            file = validGuessReader.ReadToEnd();
            string[] validGuessArray = file.Split("\r\n");
            foreach (string word in validGuessArray)
            {
                ValidWordsToGuess.Add(word.ToUpper());
                WordsToGuess.Add(word.ToUpper());
            }
            validGuessReader.Close();

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
            return WordsToGuess[rnd.Next(0, WordsToGuess.Count)];
        }
    }
}
