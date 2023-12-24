using System.Collections;

namespace SampleCodeApp.Implemnetations.CustomDictionary;

public class CustomDictionary<K,V>: ICustomDictionary<K,V>
{
    private Hashtable ht = new Hashtable();

    public V this[K k]
    {
        get
        {
            if (TryGetValue(k, out V val))
            {
                return val;
            }
            throw new KeyNotFoundException();
        }
        set
        {
            if (ht.ContainsKey(k))
            {
                ht[k] = value;
            }
            else
            {
                ht.Add(k,value);
            }
            
           
        }
    }

    public void Add(K key, V val)
    {
        if (key==null || ht.ContainsKey(key))
        {
            throw new Exception("Can not add");
        }

        ht.Add(key, val);
    }

    public bool TryAdd(K key, V val)
    {
        if ( key==null || ht.ContainsKey(key))
        {
            return false;
        }
        ht.Add(key, val);
        return true;
    }

    public bool ContainsKey(K key)
    {
       return ht.ContainsKey(key);
    }

    public bool TryGetValue(K key, out V? value)
    {
        if (ht.ContainsKey(key))
        {
            value = (V)ht[key];
            return true;
        }
        value = default(V);
        return false;
    }

    public void Remove(K key)
    {
        ht.Remove(key);
    }

    public Hashtable GetClonedHt()
    {
        return ht.Clone() as Hashtable;
    }
}