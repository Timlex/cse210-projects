using System;

namespace UwanaTimmyName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your first name? ");
            string firstName = Console.ReadLine();

            Console.WriteLine(firstName);

            Console.WriteLine("What is your last name? ");
            string lastName = Console.ReadLine();

            Console.WriteLine(lastName);
            
            Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
        }
    }
}
