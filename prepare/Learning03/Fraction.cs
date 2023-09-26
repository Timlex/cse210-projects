public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructor with no parameters (default fraction is 1/1)
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor with one parameter for the top
    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    // Constructor with two parameters for both top and bottom
    public Fraction(int top, int bottom)
    {
        numerator = top;
        denominator = bottom;
    }

    // Getter for the numerator
    public int GetNumerator()
    {
        return numerator;
    }

    // Setter for the numerator
    public void SetNumerator(int top)
    {
        numerator = top;
    }

    // Getter for the denominator
    public int GetDenominator()
    {
        return denominator;
    }

    // Setter for the denominator
    public void SetDenominator(int bottom)
    {
        // Ensure the denominator is not zero
        if (bottom != 0)
        {
            denominator = bottom;
        }
        else
        {
            // Handle the case where the denominator is set to zero
            Console.WriteLine("Denominator cannot be zero. Fraction unchanged.");
        }
    }

    // Method to return the fraction representation as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal representation of the fraction (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
