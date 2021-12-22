using System;

namespace NumberGuessingGame
{
    internal class Program
    {
        private static Random random = new Random();
        private static int correctAnswer;
        private static int lives;
        private static int answer;
        private static int hints;
        private static bool running = true;
        static void Main(string[] args)
        {
            while (running)
            {
                
                GameSetup(5, 101);
                
                while (lives > 0)
                {
                    Console.WriteLine($"You have {lives} lives remaining");
                    Console.Write("Guess the number: ");
                    try
                    {
                        answer = Convert.ToInt32(Console.ReadLine());
                        CheckAnswer(answer);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        lives--;
                        
                    }
                }
                if (lives == 0)
                {
                    Console.WriteLine("You're out of lives! You lose");
                    Console.WriteLine($"The correct answer was {correctAnswer}.");
                }
            }
        }
        public static void GameSetup(int numberOfLives , int max)
        {
            Console.WriteLine("---------");
            Console.WriteLine("New Game");
            Console.WriteLine("---------");
            correctAnswer = random.Next(1,max);
            GiveRandomHint(correctAnswer);
            lives = numberOfLives;
        }
        public static void CheckAnswer(int userAnswer)
        {
            
            if (userAnswer != correctAnswer)
            {
                lives--;
                Console.WriteLine("\nWrong answer");
                if (lives > 0)
                {
                    Console.WriteLine($"The correct answer is {AboveOrBelow(correctAnswer, answer).ToLower()}");
                }
            }
            else if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct! You win");
                lives = -1;
            }
        }
        public static void GiveRandomHint(int correctAnswer)
        {
            Console.Write("The correct answer is ");
            hints = random.Next(0,2);
            if (hints == 0 || correctAnswer == 50)
            {
                Console.WriteLine(EvenOrOdd(correctAnswer));
            }
            else if (hints == 1)
            {
                Console.WriteLine(AboveOrBelow(correctAnswer, 50));
            }
        }
        public static string EvenOrOdd(int correctAnswer)
        {
            if (correctAnswer % 2 == 0) 
            { 
                return "Even"; 
            }
            else
            {
                return "Odd";
            }
        }
        public static string AboveOrBelow(int correctAnswer, int condition)
        {
            if (correctAnswer < condition)
            {
                return $"Below {condition}";
            }
            else
            {
                return $"Above {condition}";
            }
        }
    }
}
