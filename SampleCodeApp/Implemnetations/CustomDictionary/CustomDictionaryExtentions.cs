using System.Collections;

namespace SampleCodeApp.Implemnetations.CustomDictionary;

public static class CustomDictionaryExtentions
{
    public static void PrintAllDictValues<K, V>(this CustomDictionary<K, V> customDictionary
    )
    {
        foreach (DictionaryEntry o in customDictionary.GetClonedHt())
        {   
            Console.WriteLine(o);
        }
    }
    
    /////////
    /// add implmentations of "union", "intersect", "except" and "symmetrical intersect".
    
}