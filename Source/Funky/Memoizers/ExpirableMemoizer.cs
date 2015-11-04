using System;

namespace Funky
{
    /// <summary>
    /// Represents a thread-safe memoizer for a <see cref="Func{TArg, TResult}"/> backed by a collection of key/value pairs that can be accessed by multiple threads concurrently.
    /// </summary>
    /// <typeparam name="T">The type of the keys in the memoizer.</typeparam>
    /// <typeparam name="TResult">The type of the values in the memoizer.</typeparam>
    public class ExpirableMemoizer<T, TResult> : MemoizerBase<T, TResult, WeakReference>
    {
        public ExpirableMemoizer(Func<T, TResult> func)
            : base(func)
        {
        }

        protected override TResult SetCacheValue(T key)
        {
            var value = Func(key);
            Cache.Add(key, new WeakReference(value));
            return value;
        }

        protected override TResult GetCacheValue(T key)
        {
            TResult value;
            var weakReference = Cache[key];
            if (weakReference.Target == null)
            {
                value = Func(key);
                Cache[key].Target = value;
            }
            else
            {
                value = (TResult)weakReference.Target;
            }

            return value;
        }

        protected override bool CheckCacheValue(T key)
        {
            return Cache.ContainsKey(key);
        }
    }
}