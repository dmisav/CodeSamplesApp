namespace SampleCodeApp.Examples;

public class RemoveDulicateCharacters
{
    public static void Run()
    {
        string input = Console.ReadLine();
        Console.WriteLine(RemoveDuplicates(input));
    }
    
    private static string RemoveDuplicates(string input)
    {
        return new string(input.ToHashSet().ToArray());
    }
}