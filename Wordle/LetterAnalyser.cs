using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Wordle
{
    class LetterAnalyser
    {
        public Dictionary<char, string> AlphabetList { get; set; }
        public Regex regex;
        public List<string> UserGuesses { get; set; }
        public string UserWord { get; set; }
        public string RandomWord { get; set; }
        static int totalGuesses = 6;

        public LetterAnalyser()
        {
            AlphabetList = new Dictionary<char, string>();
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                AlphabetList.Add(letter, "black");
            }

            regex = new Regex("^[a-zA-Z]+$");
            UserGuesses = new List<string>();

        }


        public void ProcessGuess()
        {
            PrintGuessResult();
            PrintAlphabetStatus();
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Remaining guesses - " + (totalGuesses - UserGuesses.Count).ToString());
           

        }

        public bool IsValidGuess()
        {

            if (this.UserWord.Length != 5)
            {
                Console.WriteLine("Must be a 5 letter word.");
                return false;
            }
            if (!regex.IsMatch(this.UserWord))
            {
                Console.WriteLine("Must be alphabet characters.");
                return false;
            }
            return true;
        }

        private void PrintGuessResult()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i <= UserWord.Length - 1; i++)
            {
                char myChar = UserWord[i];
                //check green, yellow
                if (RandomWord.Contains(myChar))
                {
                    if (myChar == RandomWord[i])
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        AlphabetList[myChar] = "green";

                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        if (AlphabetList[myChar] != "green")
                        {
                            AlphabetList[myChar] = "yellow";
                        }
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    if (AlphabetList[myChar] == "black")
                    {
                        AlphabetList[myChar] = "gray";
                    }
                }
                Console.Write(myChar);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

        }

        private void PrintAlphabetStatus()
        {

            //print alphabet
            foreach (KeyValuePair<char, string> kvp in AlphabetList)
            {
                if (kvp.Value == "green")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(kvp.Key);
                }
                else if (kvp.Value == "yellow")
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(kvp.Key);
                }
                else if (kvp.Value == "gray")
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(kvp.Key);
                }
                else if (kvp.Value == "black")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(kvp.Key);
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }

    }
   
}
