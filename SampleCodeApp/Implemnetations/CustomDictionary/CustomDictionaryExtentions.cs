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
    
    
        public static CustomDictionary<K, V> Except<K, V>(this CustomDictionary<K, V> first, CustomDictionary<K, V> second)
    {
        var result = new CustomDictionary<K, V>();
        foreach (DictionaryEntry entry in first.GetClonedHt())
        {
            var key = (K)entry.Key;
            if (!second.ContainsKey(key))
            {
                result.Add(key, (V)entry.Value);
            }
        }
        return result;
    }

    public static CustomDictionary<K, V> Intersect<K, V>(this CustomDictionary<K, V> first, CustomDictionary<K, V> second)
    {
        var result = new CustomDictionary<K, V>();
        foreach (DictionaryEntry entry in first.GetClonedHt())
        {
            var key = (K)entry.Key;
            if (second.ContainsKey(key))
            {
                result.Add(key, (V)entry.Value);
            }
        }
        return result;
    }

    public static CustomDictionary<K, V> SymmetricExcept<K, V>(this CustomDictionary<K, V> first, CustomDictionary<K, V> second)
    {
        var result = new CustomDictionary<K, V>();
        // Add items from first not in second
        foreach (DictionaryEntry entry in first.GetClonedHt())
        {
            var key = (K)entry.Key;
            if (!second.ContainsKey(key))
            {
                result.Add(key, (V)entry.Value);
            }
        }
        // Add items from second not in first
        foreach (DictionaryEntry entry in second.GetClonedHt())
        {
            var key = (K)entry.Key;
            if (!first.ContainsKey(key))
            {
                result.Add(key, (V)entry.Value);
            }
        }
        return result;
    }

    public static CustomDictionary<K, V> Union<K, V>(this CustomDictionary<K, V> first, CustomDictionary<K, V> second)
    {
        var result = new CustomDictionary<K, V>();
        foreach (DictionaryEntry entry in first.GetClonedHt())
        {
            var key = (K)entry.Key;
            result.Add(key, (V)entry.Value);
        }
        foreach (DictionaryEntry entry in second.GetClonedHt())
        {
            var key = (K)entry.Key;
            if (!result.ContainsKey(key))
            {
                result.Add(key, (V)entry.Value);
            }
        }
        return result;
    }
}