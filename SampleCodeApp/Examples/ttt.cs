using System;
using System.IO;
using System.Linq;


public class HelloWorld
{
    static public void Run()
    {
        String line;
        line = Console.ReadLine();
        int N = Convert.ToInt32(line);
        line = Console.ReadLine();
        long[] wealth = new long[N];
        wealth = line.Split().Select(str => long.Parse(str)).ToArray();

        int out_ = solve(N, wealth);
        Console.Out.WriteLine(out_);
    }

    static int solve(int N, long[] wealth)
    {
        int numPairs = 0;
        for (int i = 0;i<wealth.Length-1 ; i++)
        {
            if((wealth[i]+wealth[i+1])%3 ==0 )
            {
                numPairs = 0;
            }

        }
        return numPairs;
        // You must complete the logic for the function that is provided
        // before compiling or submitting to avoid an error.
        // Write your code here

    }

}