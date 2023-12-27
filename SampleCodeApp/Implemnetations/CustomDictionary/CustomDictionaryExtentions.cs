using System.Collections;

namespace SampleCodeApp.Implemnetations.CustomDictionary;

public static class CustomDictionaryExtentions
{
    public static void PrintAllDictValues<TK, TV>(this CustomDictionary<TK, TV> customDictionary
    )
    {
        foreach (DictionaryEntry o in customDictionary.GetClonedHt())
        {
            Console.WriteLine(o);
        }
    }
}