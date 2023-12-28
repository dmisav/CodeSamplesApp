namespace SampleCodeApp.Implemnetations.Multimap;

public class MultiMap<TKey, TValue> : IMultimap<TKey, TValue>
{
    private readonly Dictionary<TKey, HashSet<TValue>> dict = new();

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
            dict.TryAdd(key, new HashSet<TValue> { value });
        }
    }

    public HashSet<TValue> this[TKey key]
    {
        get
        {
            HashSet<TValue> hs;
            if (!this.dict.TryGetValue(key, out hs))
            {
                hs = new HashSet<TValue>();
                dict[key] = hs;
            }
            return hs;
        }
        set
        {
            dict[key] = value;
        }
    }

    public Dictionary<TKey, HashSet<TValue>>.KeyCollection Keys => dict.Keys;
}