using System;

namespace Funky
{
    /// <summary>
    /// Represents a thread-safe memoizer for a <see cref="Func{TKey, TValue}"/> backed by a collection of key/value pairs that can be accessed by multiple threads concurrently.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the memoizer.</typeparam>
    /// <typeparam name="TValue">The type of the values in the memoizer.</typeparam>
    public class ExpirableMemoizer<TKey, TValue> : MemoizerBase<TKey, TValue, WeakReference>
    {
        public ExpirableMemoizer(Func<TKey, TValue> func)
            : base(func)
        {
        }

        protected override TValue SetCacheValue(TKey key)
        {
            var value = Func(key);
            Cache.Add(key, new WeakReference(value));
            return value;
        }

        protected override TValue GetCacheValue(TKey key)
        {
            TValue value;
            var weakReference = Cache[key];
            if (weakReference.Target == null)
            {
                value = Func(key);
                Cache[key].Target = value;
            }
            else
            {
                value = (TValue)weakReference.Target;
            }

            return value;
        }

        protected override bool CheckCacheValue(TKey key)
        {
            return Cache.ContainsKey(key);
        }
    }
}