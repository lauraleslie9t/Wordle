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
                LetterAnalyser myAnalyser = new LetterAnalyser();
                Console.WriteLine("Enter a 5 letter Word");
                myAnalyser.RandomWord = newWords.GetRandomWord().ToUpper();

                Console.ForegroundColor = ConsoleColor.White;
                do 
                {
                    myAnalyser.UserWord = Console.ReadLine().Trim().ToUpper();
                    myAnalyser.UserGuesses.Add(myAnalyser.UserWord);
                    if (myAnalyser.IsValidGuess())
                    {
                        if (newWords.WordsToGuess.Contains(myAnalyser.UserWord))
                        {
                            myAnalyser.ProcessGuess();
                        }
                        else
                        {
                        Console.WriteLine("Word not in dictionary. ");

                        }
                    } 
                    if (myAnalyser.UserWord == myAnalyser.RandomWord)
                    {
                        break;
                    }

                } while (myAnalyser.UserGuesses.Count < 6);
                Console.BackgroundColor = ConsoleColor.Black;


            //give final result
            if (myAnalyser.UserGuesses.Count == 6)
                {
                    Console.WriteLine("\nYou have lost... I am sorry. The word was " + myAnalyser.RandomWord + "\n");
                }
                else
                {
                    Console.WriteLine("\nWord is a match. Please post your excitement on twitter.\n");
                }
                Console.WriteLine("Would you like to play again?(Y/N)");
                if (Console.ReadLine().ToUpper().Trim() == "N")
                {
                    playagain = false;
                } 
            } while (playagain);
          
        }

        

       
    }
}
