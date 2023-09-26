using System;

class Program
{
    static void Main()
    {
        // Create fractions using different constructors
        Fraction fraction1 = new Fraction();          // 1/1
        Fraction fraction2 = new Fraction(5);         // 5/1
        Fraction fraction3 = new Fraction(6, 7);      // 6/7

        // Display fractions using GetFractionString method
        Console.WriteLine(fraction1.GetFractionString());  // 1/1
        Console.WriteLine(fraction2.GetFractionString());  // 5/1
        Console.WriteLine(fraction3.GetFractionString());  // 6/7

        // Display decimals using GetDecimalValue method
        Console.WriteLine(fraction1.GetDecimalValue());    // 1.0
        Console.WriteLine(fraction2.GetDecimalValue());    // 5.0
        Console.WriteLine(fraction3.GetDecimalValue());    // 0.8571428571428571

        // Change the numerator and denominator using setters
        fraction1.SetNumerator(3);
        fraction1.SetDenominator(4);

        // Display the updated fraction
        Console.WriteLine(fraction1.GetFractionString());  // 3/4
    }
}
