# Wordle
Just a fun little project. 

Csv file with potential words is within bin/debug/netcoreapp3.1. 
Project imports the list, cuts all with more than 5 letters and removes all words with duplicate letters.

In the console you can write a 5 letter word. Your word will be analysed and each letter will be assigned a colour. 
Green - letter is in the word in the correct place.
Yellow - letter is in the word but the wrong position. 
Gray - Letter is not in the word.

Future Improvements/TODO
-Show the status of all chars [a-z] cafter each guess. 
-Only let guesses be actual words.

This one lets you play again rather than wait 24H. Have fun if you want to try. 