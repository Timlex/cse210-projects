using System;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                // Generate a random number between 1 and 100 (inclusive)
                Random random = new Random();
                int magicNumber = random.Next(1, 101);

                int numberOfGuesses = 0;

                Console.WriteLine("Welcome to the Guess My Number game!");
                Console.WriteLine("I have selected a magic number between 1 and 100.");
                Console.WriteLine("Try to guess it!");

                while (true)
                {
                    Console.Write("Enter your guess: ");
                    int userGuess = Convert.ToInt32(Console.ReadLine());
                    numberOfGuesses++;

                    if (userGuess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (userGuess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it in {numberOfGuesses} guesses!");
                        break;
                    }
                }

                Console.Write("Do you want to play again? (yes/no): ");
                string playAgainResponse = Console.ReadLine().ToLower();

                if (playAgainResponse != "yes")
                {
                    playAgain = false;
                }
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
