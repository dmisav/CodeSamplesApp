using System.Globalization;
using System.Runtime.InteropServices.JavaScript;

namespace SampleCodeApp.Examples;

public class AddOneToNumberFolllowedByDigit
{
    public static void Run()
    {
    }

    public static Int64 GetAddOneToNumberFolllowedByDigit(string val, int n, int m)
    {
        var arr = val.ToCharArray();
        var lst = new List<char>();
        for (var j= n; j < val.Length; j++)
        {
            
            if (Char.IsDigit(arr[j]) )
            {
                lst.Add(arr[j]);
            }
        }

        var res = Int64.Parse(string.Join("",lst));
        return res+1;
    }
}