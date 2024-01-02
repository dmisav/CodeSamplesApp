using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CS8714

namespace Challenges
{
    public interface IMultiValueDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        /// <summary>
        /// Adds a value to either existing key or creates a new key and adds the value to it if the key value pair does not already exist
        /// </summary>
        /// <param name="key">Key to add value to</param>
        /// <param name="value">Value to add</param>
        /// <returns>true if the underlying collection has changed; false otherwise</returns>
        bool Add(K key, V value);

        /// <summary>
        /// Returns a sequence of values for the given key. throws KeyNotFoundException if the key is not present
        /// </summary>
        /// <param name="key">key to retrieve the sequence of values for</param>
        /// <returns>sequence of values for the given key</returns>
        IEnumerable<V> Get(K key);

        /// <summary>
        /// Returns a sequence of values for the given key. returns empty sequence if the key is not present
        /// </summary>
        /// <param name="key">key to retrieve the sequence of values for</param>
        /// <returns>sequence of values for the given key</returns>
        IEnumerable<V> GetOrDefault(K key);

        /// <summary>
        /// Removes the value from the values associated with the given key. throws KeyNotFoundException if the key is not present
        /// </summary>
        /// <param name="key">key which values need to be adjusted</param>
        /// <param name="value">value to remove from the values for the given key</param>
        void Remove(K key, V value);

        /// <summary>
        /// Removes the given key from the dictionary with all the values associated with it
        /// </summary>
        /// <param name="key">key to remove from the dictionary</param>
        void Clear(K key);

        /// <summary>
        /// Returns a sequence of items of KeyValuePair<K, V> type, flattening the internal collection.
        /// </summary>
        /// 
        /// <example> 
        /// var creatures = new MultiValueDictionary<string, string>();
        /// creatures.Add("birds", "eagle");
        /// creatures.Add("birds", "dove");
        /// creatures.Add("animals", "tiger");
        /// 
        /// foreach (KeyValuePair<string, string> pair in creatures.Flatten()) {
        ///     Console.WriteLine($"<{pair.Key}, {pair.Value}>");
        /// }
        /// 
        /// This will print 3 pairs:        
        /// <birds, eagle>
        /// <birds, dove>
        /// <animals, tiger>
        /// 
        /// </example>
        /// <references>
        /// KeyValuePair<TKey, TValue>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair-2?view=netframework-4.7.2
        /// IEnumerable<T>: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1?view=netframework-4.7.2
        /// </references>
        IEnumerable<KeyValuePair<K, V>> Flatten();
    }

    /* public class MultiValueDictionary<K, V> : IMultiValueDictionary<K, V>
     {
         private readonly Dictionary<K, HashSet<V>> _dict = new();

         public bool Add(K key, V value)
         {
             if (_dict.ContainsKey(key))
             {
                 return _dict[key].Add(value); // hasset Add should retun false if  duplicate
             }
             else
             {
                 _dict.Add(key, new HashSet<V> { value });
                 return true;
             }
         }

         public IEnumerable<V> Get(K key)
         {
             if (!_dict.ContainsKey(key))
             {
                 throw new KeyNotFoundException();
             }
             else
             {
                 return _dict[key];
             }
         }

         public IEnumerable<V> GetOrDefault(K key)
         {
             if (!_dict.ContainsKey(key))
             {
                 return new HashSet<V>();
             }
             else
             {
                 return _dict[key];
             }
         }

         public void Remove(K key, V value)
         {
             if (!_dict.ContainsKey(key))
             {
                 throw new KeyNotFoundException();
             }
             else
             {
                 _dict[key].Remove(value);
             }
         }

         public void Clear(K key)
         {
             if (key != null)
                 _dict.Remove(key);
         }*/

    public class MultiValueDictionary<K, V> : IMultiValueDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
        private readonly Dictionary<K, HashSet<V>> _dict = new();

        public bool Add(K key, V value)
        {
            if (_dict.ContainsKey(key))
            {
                return _dict[key].Add(value); // hasset Add should retun false if  duplicate                
            }
            else
            {
                _dict.Add(key, new HashSet<V> { value });
                return true;
            }
        }

        public IEnumerable<V> Get(K key)
        {
            if (!_dict.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return _dict[key];
            }
        }

        public IEnumerable<V> GetOrDefault(K key)
        {
            if (!_dict.ContainsKey(key))
            {
                return default(HashSet<V>);
            }
            else
            {
                return _dict[key];
            }
        }

        public void Remove(K key, V value)
        {
            if (!_dict.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }
            else
            {
                _dict[key].Remove(value);
            }
        }

        public void Clear(K key)
        {
            if (key != null)
                _dict.Remove(key);
        }

        public IEnumerable<KeyValuePair<K, V>> Flatten()
        {
            return _dict.SelectMany(pair => pair.Value.Select(value => new KeyValuePair<K, V>(pair.Key, value)));
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return Flatten().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}