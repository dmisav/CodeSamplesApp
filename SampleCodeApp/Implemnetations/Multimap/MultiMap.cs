using SampleCodeApp.Implemnetations.Multimap;

namespace SampleCodeApp.Examples;

public class MultiMap<TKey, TValue> : IMultimap<TKey,TValue>
{
    private readonly Dictionary<TKey, IList<TValue>> dict = new();

    public IEnumerable<TValue> GetValueForKey(TKey k)
    {
        return dict[k];
    }

    public void Add(TKey key, TValue value)
    {
        if (dict.ContainsKey(key))
        {
            dict[key].Add(value);
        }
        else
        {
            dict.TryAdd(key, new List<TValue>{value});
        }
    }
}