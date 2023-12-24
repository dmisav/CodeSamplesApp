namespace SampleCodeApp.Implemnetations.CustomDictionary;

public interface ICustomDictionary<K,V>
{
    void Add(K key, V val);
    bool TryAdd(K key, V val);
    bool ContainsKey(K key);
    bool TryGetValue(K key, out V? value);
    void Remove(K key);
}