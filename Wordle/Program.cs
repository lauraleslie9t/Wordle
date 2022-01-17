using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Wordle
{
    class Program
    {

        static void Main(string[] args)
        {
            ValidWords newWords = new ValidWords();
            bool playagain = true;
            do
            {
                Console.WriteLine("Enter a 5 letter Word");
                //string startingWord = "frogs".ToUpper();
                string startingWord = newWords.GetRandomWord().ToUpper();

                int remainingGuesses = 5;
                Console.ForegroundColor = ConsoleColor.White;
                //run the guess logic
                do
                {
                    string userInput = Console.ReadLine().Trim().ToUpper();
                    if (ValidateGuess(userInput))
                    {
                        ShowGuessResult(userInput, startingWord);
                    }
                    if (userInput == startingWord)
                    {
                        break;
                    }
                    remainingGuesses--;
                    Console.WriteLine("Remaining guesses - " + remainingGuesses);
                } while (remainingGuesses > 0);

                //give final result
                if (remainingGuesses == 0)
                {
                    Console.WriteLine("You have lost... I am sorry. The word was " + startingWord + "\n");
                }
                else
                {
                    Console.WriteLine("Word is a match. Please post your excitement on twitter.\n");
                }

                Console.WriteLine("Would you like to play again?(Y/N)");
                if (Console.ReadLine().ToUpper().Trim() == "N")
                {
                    playagain = false;
                } 
            } while (playagain);
          
        }

        public static bool ValidateGuess(string input)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");
            if (input.Length != 5)
            {
                Console.WriteLine("Must be a 5 letter word.");
                return false;
            }
            if (!regex.IsMatch(input))
            {
                Console.WriteLine("Must be alphabet characters.");
                return false;
            }
            return true;
        }

        public static void ShowGuessResult(string inputWord, string startingWord)
        {
            Dictionary<char, int> charPos = new Dictionary<char, int>();
            //check each letters existance/position
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    if (inputWord[i] == startingWord[j])
                    {
                        charPos.Add(startingWord[i], i); 
                    }
                }
            }
            //print with the colors
            for (int i = 0; i <= 4; i++)
            {
                char currentChar = inputWord[i];
                Console.ForegroundColor = ConsoleColor.Black;

                if (charPos.ContainsKey(currentChar))
                {
                    if (charPos[currentChar] == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write(currentChar);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
