namespace SampleCodeApp.Examples;

public class SumDigitsPositiveInteger
{
    public static void Run()
    {
        var input = Console.ReadLine();
        int sum = Sum(input);
        Console.WriteLine(sum);
    }

    private static int Sum(string input)
    {
        int res = 0;
        foreach (var el in input)
        {
            int.TryParse(el.ToString(), out int r);
            res += r;
        }
        return res;
    }

}