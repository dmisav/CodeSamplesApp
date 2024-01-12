namespace SampleCodeApp.LINQ;

public class LinqPractices
{
    /// <summary>
    ///  Write a program in C# Sharp to find the number of an array and the square of each number.
    /// Expected Output :
    /// { Number = 9, SqrNo = 81 }
    /// { Number = 8, SqrNo = 64 }
    /// { Number = 6, SqrNo = 36 }
    /// { Number = 5, SqrNo = 25 }
    /// </summary>
    public void NumberSquare()
    {
        int[] arr = { 1, 3, 4, 6, 7 };

        arr.Select(i => new { i, p = i * i }).ToList();

    }
/// <summary>
/// Write a program in C# Sharp to display the number and frequency of a given number from an array.
/// Expected Output :
/// The number and the Frequency are :
/// Number 5 appears 3 times
/// Number 9 appears 2 times
/// Number 1 appears 1 times
/// </summary>
    public void NumberCount()
    {
        int[] arr = { 1, 3, 4, 3, 6, 1, 7 };
        arr.GroupBy(i => i).Select(el => new { el.Key, Count = el.Count() });
    }
/// <summary>
/// Write a program in C# Sharp to display the characters and frequency of each character in a given string.
/// Test Data:
/// Input the string: apple
/// Expected Output:
/// The frequency of the characters are :
/// Character a: 1 times
/// Character p: 2 times
/// Character l: 1 times
/// Character e: 1 times
/// </summary>
    public void EachCharacterNumberInString()
{
    var str = "apple";
    str.GroupBy(i => i).Select(el => new { el.Key, Count = el.Count() });
}

public void PrintAllDaysOfWeeek()
{
    foreach (var el in Enum.GetValues(typeof(DayOfWeek)))
    {
        Console.WriteLine(nameof(el).ToString());
    }
}

}