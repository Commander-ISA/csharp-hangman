using System;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "apple", "banana", "cherry", "orange", "grape" };
            Random random = new Random();
            int index = random.Next(words.Length);
            string word = words[index];
            char[] display = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                display[i] = '_';
            }
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("The word is: " + new string(display));
            int guesses = 0;
            int maxGuesses = 6;
            while (guesses < maxGuesses)
            {
                Console.Write("Guess a letter: ");
                char letter = char.ToLower(Console.ReadKey().KeyChar);
                if (!Char.IsLetter(letter))
                {
                    Console.WriteLine("\nPlease enter a letter.");
                    continue;
                }
                bool found = false;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        display[i] = letter;
                        found = true;
                    }
                }
                if (!found)
                {
                    guesses++;
                    Console.WriteLine("\nSorry, the letter is not in the word.");
                    Console.WriteLine("You have " + (maxGuesses - guesses) + " guesses left.");
                }
                else
                {
                    Console.WriteLine("\nGood job! You found a letter.");
                    Console.WriteLine("The word is: " + new string(display));
                }
                if (new string(display) == word)
                {
                    Console.WriteLine("Congratulations, you guessed the word!");
                    break;
                }
            }
            if (new string(display) != word)
            {
                Console.WriteLine("Sorry, you ran out of guesses. The word was: " + word);
            }
            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }
    }
}
