namespace SampleCodeApp.Examples;

public static class PalindromeString
{
    public static void Run()
    {
        string words = Console.ReadLine();
        bool res = false;
        if(!string.IsNullOrEmpty(words))
        {
            res = IsPalindrome(words);
        }
        Console.WriteLine(res ? "Is": "Not");
    }
    
    private static bool IsPalindrome(string inputStr)
    {
        bool isPal = true;
        for(int i = 0, k = inputStr.Length-1; i<inputStr.Length/2 && k>=inputStr.Length/2+1; i++, k-- )
        {           
            if(inputStr[i] != inputStr[k])
            {
                return false;                
            }
        }
        return isPal;
    }
}