using System.Globalization;
using System.Runtime.InteropServices.JavaScript;

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
}