using System;
using System.Collections.Generic;
using System.Threading;

namespace Funky
{
    /// <summary>
    /// Represents a thread-safe memoizer for a <see cref="Func{TKey, TValue}"/> backed by a collection of key/value pairs that can be accessed by multiple threads concurrently.
    /// </summary>
    /// <typeparam name="TKey">The type of memoizer's keys.</typeparam>
    /// <typeparam name="TValue">The type of the memoizer's return values.</typeparam>
    /// <typeparam name="TCachedValue">Th type of the memoizer's cahced values.</typeparam>
    public abstract class MemoizerBase<TKey, TValue, TCachedValue> : IMemoizeThings<TKey, TValue>
    {
        protected MemoizerBase(Func<TKey, TValue> func)
            : this()
        {
            Func = func;
        }

        private MemoizerBase()
        {
            Cache = new Dictionary<TKey, TCachedValue>();
            CacheLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue GetOrAdd(TKey key)
        {
            TValue result;

            CacheLock.EnterWriteLock();
            try
            {
                result = CheckCacheValue(key) ? GetCacheValue(key) : SetCacheValue(key);
            }
            finally
            {
                CacheLock.ExitWriteLock();
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get
            {
                return GetOrAdd(key);
            }
        }

        protected abstract bool CheckCacheValue(TKey key);

        protected abstract TValue SetCacheValue(TKey key);

        protected abstract TValue GetCacheValue(TKey key);

        protected Dictionary<TKey, TCachedValue> Cache { get; private set; }

        protected ReaderWriterLockSlim CacheLock { get; }

        protected Func<TKey, TValue> Func { get; private set; }
    }
}