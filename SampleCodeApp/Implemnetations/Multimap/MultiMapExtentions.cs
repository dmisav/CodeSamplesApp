using SampleCodeApp.Examples;

namespace SampleCodeApp.Implemnetations.Multimap;

public static class MultiMapExtentions
{
    public static IMultimap<TK, TV> Union<TK, TV>(this IMultimap<TK, TV> source, 
        IMultimap<TK, TV> other)
    {
        var unifiedDic = new MultiMap<TK, TV>();
        foreach (var key in source.Keys.Concat(other.Keys).Distinct())
        {
            unifiedDic[key] = source[key].Union(other[key]).ToHashSet();
        }
        return unifiedDic;
    }

    public static IMultimap<TK, TV> Except<TK, TV>(this IMultimap<TK, TV> source,
        IMultimap<TK, TV> other)
    {
        var exceptDic = new MultiMap<TK, TV>();
        foreach (var key in source.Keys.Except(other.Keys).Distinct())
        {
            exceptDic[key] = source[key].Except(other[key]).ToHashSet();
        }

        return exceptDic;
    }
    
    public static IMultimap<TK, TV> Intersect<TK, TV>(this IMultimap<TK, TV> source,
        IMultimap<TK, TV> other)
    {
        var intersectDic = new MultiMap<TK, TV>();
        foreach (var key in source.Keys.Intersect(other.Keys).Distinct())
        {
            intersectDic[key] = source[key].Intersect(other[key]).ToHashSet();
        }

        return intersectDic;
    }
    
    public static MultiMap<TKey, TValue> SymmetricExcept<TKey, TValue>(
        this MultiMap<TKey, TValue> source,
        MultiMap<TKey, TValue> other)
    {
        var symmetricExceptMap = new MultiMap<TKey, TValue>();

        foreach (var key in source.Keys.Concat(other.Keys).Distinct())
        {
            source[key].SymmetricExceptWith(other[key]);
            symmetricExceptMap[key] = source[key];
        }

        return symmetricExceptMap;
    }

}