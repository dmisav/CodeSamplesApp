namespace SampleCodeApp.Examples;

public class weirdSolution
{
    public static void Run()
    {
        // Input: Get a positive real number from the user
        Console.Write("Enter a positive real number: ");
        if (double.TryParse(Console.ReadLine(), out double number) && number >= 0)
        {
            // Calculate the sum of digits
            double sum = SumOfDigits(number);

            // Output the result
            Console.WriteLine($"Sum of digits for {number}: {sum}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid positive real number.");
        }
    }
    
    static double SumOfDigits(double n)
    {
        double sum = 0;

        // Extract and add each digit to the sum
        while (n > 0)
        {
            sum += n % 10;   // Add the last digit to the sum
            n /= 10;         // Remove the last digit
        }

        return sum;
    }
    
}