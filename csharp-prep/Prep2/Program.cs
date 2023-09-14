using System;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your grade percentage: ");
            int gradePercentage = Convert.ToInt32(Console.ReadLine());

            string letter = ""; // Initialize the letter grade variable

            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            // Check if the user passed the course
            if (gradePercentage >= 70)
            {
                Console.WriteLine($"Your grade is {letter}. Congratulations, you passed!");
            }
            else
            {
                Console.WriteLine($"Your grade is {letter}. Keep working hard for next time.");
            }

            // Stretch challenge: Determine the sign (+, -)
            int lastDigit = gradePercentage % 10;
            string sign = "";

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }

            // Handle exceptional cases (A+, F+, F-)
            if (letter == "A" && lastDigit >= 7)
            {
                letter = "A+";
                sign = "";
            }
            else if (letter == "F" && (lastDigit >= 7 || lastDigit < 3))
            {
                letter = "F";
                sign = "";
            }

            // Display the grade with the sign
            Console.WriteLine($"Your final grade is {letter}{sign}");
        }
    }
}
