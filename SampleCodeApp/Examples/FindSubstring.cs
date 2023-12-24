namespace SampleCodeApp.Examples;

public class FindSubstring
{
    public static void Run()
    {
        Console.WriteLine("Enter String and Substring with ':' separator");
        var input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input) && input.Contains(';'))
        {
            var split = input.Split(';');
            string str = split[0];
            string subStr = split[1];

            if (str.Contains(subStr))
            {
                Console.WriteLine($"substring '{subStr}' is part of input string");
                Console.WriteLine($"substring '{str.IndexOf(subStr)}' has following index");
            }
        }
    }
}