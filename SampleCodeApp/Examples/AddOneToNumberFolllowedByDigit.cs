using System.Text.RegularExpressions;

namespace SampleCodeApp.Examples;

public class AddOneToNumberFolllowedByDigit
{
    public static void Run()
    {
    }

    public static string GetAddOneToNumberFolllowedByDigit(string val)
    {
        var lst = new List<char>();
        var clst = new List<char>();
        for (var j= 0; j < val.Length; j++)
        {
            if (Char.IsDigit(val[j]) )
            {
                lst.Add(val[j]);
            }
            else
            {
                clst.Add(val[j]);
            }
        }
        var ires = Int64.Parse(string.Join("",lst)) + 1;
        var res = new string(clst.ToArray()) + ires.ToString();
        return  res;
    }

    public static string GetAddOnRegex(string input)
    {
        var pattern = "([a-zA-Z]+)([0-9]+)";
        var res = Regex.Match(input, pattern);
        var ires = Int64.Parse(res.Groups[2].Value) + 1;
        return $"{res.Groups[1].Value}{ires}";
    }
}

/*
DECLARE @input NVARCHAR(100) = 'abc123';
   
   -- Find the start of the numeric part
   DECLARE @startOfNumbers INT;
   SET @startOfNumbers = PATINDEX('%[0-9]%', @input);
   
   -- Extract the letters
   DECLARE @letters NVARCHAR(100);
   SET @letters = SUBSTRING(@input, 1, @startOfNumbers - 1);
   
   -- Extract the numbers
   DECLARE @numbers NVARCHAR(100);
   SET @numbers = SUBSTRING(@input, @startOfNumbers, LEN(@input));
   
   SELECT 'Letters' AS Part, @letters AS Value
   UNION ALL
   SELECT 'Numbers' AS Part, @numbers AS Value;
*/