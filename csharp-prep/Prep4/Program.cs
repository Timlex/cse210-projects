using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberListAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int number;

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            do
            {
                Console.Write("Enter number: ");
                number = Convert.ToInt32(Console.ReadLine());

                if (number != 0)
                {
                    numbers.Add(number);
                }

            } while (number != 0);

            if (numbers.Count > 0)
            {
                int sum = numbers.Sum();
                double average = numbers.Average();
                int max = numbers.Max();

                Console.WriteLine($"The sum is: {sum}");
                Console.WriteLine($"The average is: {average}");
                Console.WriteLine($"The largest number is: {max}");

                // Stretch Challenge
                var positiveNumbers = numbers.Where(n => n > 0);
                if (positiveNumbers.Any())
                {
                    int smallestPositive = positiveNumbers.Min();
                    Console.WriteLine($"The smallest positive number is: {smallestPositive}");
                }

                Console.WriteLine("The sorted list is:");
                numbers.Sort();
                foreach (var num in numbers)
                {
                    Console.WriteLine(num);
                }
            }
            else
            {
                Console.WriteLine("No numbers entered.");
            }
        }
    }
}
