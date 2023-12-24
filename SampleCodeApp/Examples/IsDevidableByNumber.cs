namespace SampleCodeApp.Examples;

public class IsDevidableByNumber
{
    public static void Run()
    {
        var res = IsDivisableByGivenNumbers(9, 2, 5);
        
        Console.WriteLine(res ? "Is": "Not");
    }
    
    private static bool IsDivisableByGivenNumbers(int val, int par1, int par2)
    {
        bool res = false;
        if(val%par1==0 && val%par2==0)
        {
            return true;
        }
        return res;    
    }  
}