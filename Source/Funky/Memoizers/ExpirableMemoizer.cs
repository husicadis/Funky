using System;

namespace Funky
{
    /// <summary>
    /// Represents a thread-safe memoizer for a given <see cref="Func{TKey, TValue}"/>.  The memoizer's cached values can be expire and be garbage-collected.
    /// </summary>
    /// <typeparam name="TKey">The type of the memoizer's keys.</typeparam>
    /// <typeparam name="TValue">The type of the memoizer's return values.</typeparam>
    public class ExpirableMemoizer<TKey, TValue> : MemoizerBase<TKey, TValue, WeakReference>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpirableMemoizer{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="func">The encapsulated method that this memoizer will memoize.</param>
        public ExpirableMemoizer(Func<TKey, TValue> func)
            : base(func)
        {
        }

        protected override TValue SetValue(TKey key)
        {
            var value = Func(key);
            Cache.Add(key, new WeakReference(value));
            return value;
        }

        protected override TValue GetValue(TKey key)
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

        protected override bool ContainsKey(TKey key)
        {
            return Cache.ContainsKey(key);
        }
    }
}