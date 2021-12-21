using System;

namespace NumberGuessingGame
{
    internal class Program
    {
        private const int maxNumber = 100;
        private static Random random = new Random();
        private static int correctAnswer = random.Next(maxNumber);
        private static int lives = 5;
        private static int answer;
        static void Main(string[] args)
        {
            
            GiveHints(correctAnswer);
            while (lives > 0)
            {
                Console.WriteLine($"{lives} lives remaining");
                Console.Write("Guess the number: ");
                answer = Convert.ToInt32(Console.ReadLine());
                if (answer != correctAnswer)
                {
                    lives--;
                    Console.WriteLine("\nWrong answer, try again!");
                    Console.WriteLine($"The correct answer is {AboveOrBelow(correctAnswer, answer).ToLower()}");
                    
                }
                else if(answer == correctAnswer)
                {
                    Console.WriteLine("Correct! You win");
                    lives = 0;
                }
            }
            Console.WriteLine($"The correct answer was {correctAnswer}.");

        }
        public static void GiveHints(int correctAnswer)
        {
            Console.WriteLine(EvenOrOdd(correctAnswer));
            Console.WriteLine(AboveOrBelow(correctAnswer, 50));
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
