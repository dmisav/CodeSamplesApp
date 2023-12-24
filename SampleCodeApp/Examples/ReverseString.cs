namespace SampleCodeApp.Examples;

public class ReverseString
{
    public static void Run()
    {
        var input = Console.ReadLine();
        char[] inputArr = input.ToCharArray();
        Array.Reverse(inputArr);
        var revStr = string.Join("", inputArr);
        Console.WriteLine(revStr);
    }
}