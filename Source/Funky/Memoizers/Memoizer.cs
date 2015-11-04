using System;

namespace Funky
{
    /// <summary>
    /// Represents a persistent thread-safe memoizer for a given <see cref="Func{TKey, TValue}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the memoizer's keys.</typeparam>
    /// <typeparam name="TValue">The type of the memoizer's return values.</typeparam>
    public class Memoizer<TKey, TValue> : MemoizerBase<TKey, TValue, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Memoizer{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="func">The encapsulated method that this memoizer will memoize.</param>
        public Memoizer(Func<TKey, TValue> func)
            : base(func)
        {
        }

        protected override TValue SetValue(TKey key)
        {
            var value = Func(key);
            Cache.Add(key, value);
            return value;
        }

        protected override TValue GetValue(TKey key)
        {
            return Cache[key];
        }

        protected override bool ContainsKey(TKey key)
        {
            return Cache.ContainsKey(key);
        }
    }
}