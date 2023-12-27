namespace SampleCodeApp.Implemnetations.Multimap;

public interface IMultimap<TKey,TValue>
{
    IEnumerable<TValue> GetValueForKey(TKey k);

    void Add(TKey key, TValue value);

    public HashSet<TValue> this[TKey key] { get; }
    Dictionary<TKey, HashSet<TValue>>.KeyCollection Keys { get; }
}