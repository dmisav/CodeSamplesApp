using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/*
namespace Challenges
{
    /// <summary>
    /// see http://res.cloudinary.com/dyd911kmh/image/upload/f_auto,q_auto:best/v1526998740/15_union_intersection_difference_symmetric.png
    /// </summary>
    public static class IMultiValueDictionaryExtensions 
    {    
        /// <summary>
        /// Modifies the current IMultiValueDictionary<K, V> instance to contain all elements that are present in itself,
        /// the specified collection, or both.
        /// </summary>
        /// <param name="other">The collection to compare to the current IMultiValueDictionary<K, V> instance</param>
        /// <returns>the current IMultiValueDictionary<K, V> instance</returns>
        public static IMultiValueDictionary<K, V> UnionWith<K, V>(this IMultiValueDictionary<K, V> @this, IMultiValueDictionary<K, V> other)
        {
            var unifiedDic = MultiValueDictionary<K, V>();
           
            foreach (var key in other)
            {
                unifiedDic.Add( kvp.Key, kvp.Value.Union(other.Contains( kvp.Key ) ? other[kvp.Key] : Enumerable.Empty<V>() ).ToHashSet());
            }
            foreach (var key in other)
            {
                if(!@this.Contains(key.Key))
                {
                    unifiedDic.Add(key, key.Value);
                }
            }
            @this = unifiedDic;
            return @this;
        }
    
        /// <summary>
        /// Removes all elements in the specified collection from the current IMultiValueDictionary<K, V> instance.
        /// </summary>
        /// <param name="other">The collection of items to remove from the current IMultiValueDictionary<K, V> instance</param>
        /// <returns>the current IMultiValueDictionary<K, V> instance</returns>
        public static IMultiValueDictionary<K, V> ExceptWith<K, V>(this IMultiValueDictionary<K, V> @this, IMultiValueDictionary<K, V> other)
        {
            var dic = MultiValueDictionary<K, V>();
            
            foreach( el in @other)
            {                               
                if(@this[el.])
                {
                    dic.Add(el);
                }
            }
            foreach( i in dic )
            {
                dic[i.Key].Ex
            }
            return @this;
        }
    
        /// <summary>
        /// Modifies the current IMultiValueDictionary<K, V> instance to contain only elements that are present in that object 
        /// and in the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current IMultiValueDictionary<K, V> instance</param>
        /// <returns>the current IMultiValueDictionary<K, V> instance</returns>
        public static IMultiValueDictionary<K, V> IntersectWith<K, V>(this IMultiValueDictionary<K, V> @this, IMultiValueDictionary<K, V> other)
        {
            throw new NotImplementedException();    
            
            return @this;
        }
    
        /// <summary>
        /// Modifies the current IMultiValueDictionary<K, V> instance to contain only elements that are present either in that object 
        /// or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">The collection to compare to the current IMultiValueDictionary<K, V> instance</param>
        /// <returns>the current IMultiValueDictionary<K, V> instance</returns>
        public static IMultiValueDictionary<K, V> SymmetricExceptWith<K, V>(this IMultiValueDictionary<K, V> @this, IMultiValueDictionary<K, V> other)
        {
            throw new NotImplementedException();
            
            return @this;
        }
    }
    
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
    
    public class MultiValueDictionary<K, V> : IMultiValueDictionary<K, V>
    {
        private readonly Dictionary<K, HashSet<V>> items = new Dictionary<K, HashSet<V>>();

        public bool Add(K key, V value)
        {
            if (items.TryGetValue(key, out var values))
            {
                return values.Add(value);
            }
            
            items[key] = new HashSet<V> { value };
            return true;
        }

        public void Clear(K key)
        {
            items.Remove(key);
        }

        public IEnumerable<KeyValuePair<K, V>> Flatten()
        {
            foreach (var pair in items)
            {
                foreach (var value in pair.Value)
                {
                    yield return new KeyValuePair<K, V>(pair.Key, value);
                }
            }
        }

        public IEnumerable<V> Get(K key)
        {
            return items[key].AsEnumerable();
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            return Flatten().GetEnumerator();
        }

        public IEnumerable<V> GetOrDefault(K key)
        {
            if (items.TryGetValue(key, out var values))
            {
                return values;
            }
            
            return Enumerable.Empty<V>();
        }

        public void Remove(K key, V value)
        {
            var values = items[key];
            values.Remove(value);

            if (values.Count == 0)
            {
                items.Remove(key);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
// Test suit for MultiValueDictionary
// Insert below the implementation

    public class MultiValueDictionaryTests
    {
        public void Run()
        {
            InvokeTest(UnionWith_TwoLists);
            InvokeTest(ExceptWith_TwoLists);
            InvokeTest(IntersectWith_TwoLists);
            InvokeTest(SymmetricExceptWith_TwoLists);
        }

        private void ExceptWith_TwoLists()
        {
            MultiValueDictionary<string, string> mvd = new MultiValueDictionary<string, string>();
            mvd.Add("birds", "eagle");
            mvd.Add("birds", "dove");
            mvd.Add("cats", "tiger");
            mvd.Add("cats", "lion");
            mvd.Add("fish", "bass");
            mvd.Add("fish", "goldfish");
            mvd.Add("fish", "beta");
            mvd.Add("reptile", "crocodile");
            
            MultiValueDictionary<string, string> mvd2 = new MultiValueDictionary<string, string>();
            mvd2.Add("birds", "dove");
            mvd2.Add("cats", "lion");
            mvd2.Add("fish", "goldfish");
            mvd2.Add("fish", "beta");
            mvd2.Add("cats", "liger");
            mvd2.Add("mammal", "koala");
            
            mvd.ExceptWith(mvd2);
            
            var values = mvd.Get("birds").ToList();

            Assert(values.Count == 1);
            Assert(values.Any(i => i == "eagle"));

            values = mvd.Get("cats").ToList();

            Assert(values.Count == 1);
            Assert(values.Any(i => i == "tiger"));
            
            values = mvd.Get("fish").ToList();

            Assert(values.Count == 1);
            Assert(values.Any(i => i == "bass"));
            
            values = mvd.Get("reptile").ToList();
            
            Assert(values.Count == 1);
            Assert(values.Any(i => i == "crocodile"));
            
            values = mvd.GetOrDefault("mammal").ToList();
            
            Assert(values.Count == 0);
        }
        
        private void UnionWith_TwoLists()
        {
            MultiValueDictionary<string, string> mvd = new MultiValueDictionary<string, string>();
            mvd.Add("birds", "eagle");
            mvd.Add("birds", "dove");
            mvd.Add("cats", "tiger");
            mvd.Add("cats", "lion");
            mvd.Add("fish", "bass");
            mvd.Add("fish", "goldfish");
            mvd.Add("fish", "beta");
            mvd.Add("reptile", "crocodile");
            
            MultiValueDictionary<string, string> mvd2 = new MultiValueDictionary<string, string>();
            mvd2.Add("birds", "dove");
            mvd2.Add("cats", "lion");
            mvd2.Add("fish", "goldfish");
            mvd2.Add("fish", "beta");
            mvd2.Add("cats", "liger");
            mvd2.Add("mammal", "koala");
            
            mvd.UnionWith(mvd2);
            
            var values = mvd.Get("birds").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "eagle"));
            Assert(values.Any(i => i == "dove"));

            values = mvd.Get("cats").ToList();

            Assert(values.Count == 3);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "lion"));
            Assert(values.Any(i => i == "liger"));
            
            values = mvd.Get("fish").ToList();

            Assert(values.Count == 3);
            Assert(values.Any(i => i == "bass"));
            Assert(values.Any(i => i == "goldfish"));
            Assert(values.Any(i => i == "beta"));
            
            values = mvd.Get("reptile").ToList();
            
            Assert(values.Count == 1);
            Assert(values.Any(i => i == "crocodile"));
            
            values = mvd.Get("mammal").ToList();
            
            Assert(values.Count == 1);
            Assert(values.Any(i => i == "koala"));
        }

        private void IntersectWith_TwoLists()
        {
            MultiValueDictionary<string, string> mvd = new MultiValueDictionary<string, string>();
            mvd.Add("birds", "eagle");
            mvd.Add("birds", "dove");
            mvd.Add("cats", "tiger");
            mvd.Add("cats", "lion");
            mvd.Add("fish", "bass");
            mvd.Add("fish", "goldfish");
            mvd.Add("fish", "beta");
            mvd.Add("reptile", "crocodile");
            
            MultiValueDictionary<string, string> mvd2 = new MultiValueDictionary<string, string>();
            mvd2.Add("birds", "dove");
            mvd2.Add("cats", "lion");
            mvd2.Add("fish", "goldfish");
            mvd2.Add("fish", "beta");
            mvd2.Add("cats", "liger");
            mvd2.Add("mammal", "koala");
            
            mvd.IntersectWith(mvd2);
            
            var values = mvd.Get("birds").ToList();

            Assert(values.Count == 1);
            Assert(values.Any(i => i == "dove"));

            values = mvd.Get("cats").ToList();

            Assert(values.Count == 1);
            Assert(values.Any(i => i == "lion"));
            
            values = mvd.Get("fish").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "goldfish"));
            Assert(values.Any(i => i == "beta"));
            
            values = mvd.GetOrDefault("reptile").ToList();
            
            Assert(values.Count == 0);
            
            values = mvd.GetOrDefault("mammal").ToList();
            
            Assert(values.Count == 0);            
        }

        private void SymmetricExceptWith_TwoLists()
        {
            MultiValueDictionary<string, string> mvd = new MultiValueDictionary<string, string>();
            mvd.Add("birds", "eagle");
            mvd.Add("birds", "dove");
            mvd.Add("cats", "tiger");
            mvd.Add("cats", "lion");
            mvd.Add("fish", "bass");
            mvd.Add("fish", "goldfish");
            mvd.Add("fish", "beta");
            mvd.Add("reptile", "crocodile");
            
            MultiValueDictionary<string, string> mvd2 = new MultiValueDictionary<string, string>();
            mvd2.Add("birds", "dove");
            mvd2.Add("cats", "lion");
            mvd2.Add("fish", "goldfish");
            mvd2.Add("fish", "beta");
            mvd2.Add("fish", "halibut");
            mvd2.Add("cats", "liger");
            mvd2.Add("mammal", "koala");
            
            mvd.SymmetricExceptWith(mvd2);
            
            var values = mvd.Get("birds").ToList();

            Assert(values.Count == 1);
            Assert(values.Any(i => i == "eagle"));

            values = mvd.Get("cats").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "tiger"));
            Assert(values.Any(i => i == "liger"));
            
            values = mvd.Get("fish").ToList();

            Assert(values.Count == 2);
            Assert(values.Any(i => i == "bass"));
            Assert(values.Any(i => i == "halibut"));
            
            values = mvd.Get("reptile").ToList();
            
            Assert(values.Count == 1);
            Assert(values.Any(i => i == "crocodile"));
            
            values = mvd.Get("mammal").ToList();
            
            Assert(values.Count == 1);
            Assert(values.Any(i => i == "koala"));
        }

        // helpers

        private void InvokeTest(Action test)
        {
            var testName = test.Method.Name;

            try 
            {
                test();
                Console.WriteLine($"> {testName}: OK");
            }
            catch (Exception e) 
            {
                if (e is AggregateException)
                    e = e.InnerException;
                Console.WriteLine($"> {testName}: FAILED ({e.Message})");
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void Assert(bool result)
        {
            if (!result)
            {
                throw new Exception("Assertion failed.");
            }
        }

        private static void AssertFails<TException>(Action action)
            where TException : Exception
        {
            AssertFails(action, typeof(TException));
        }

        private static void AssertFails(Action action, Type exceptionType)
        {
            try 
            {
                action();
                throw new Exception($"Assertion failed: {exceptionType} wasn't thrown.");
            }
            catch (Exception e) 
            {
                Assert(exceptionType.IsInstanceOfType(e));
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            new MultiValueDictionaryTests().Run();
        }
    }    
}*/