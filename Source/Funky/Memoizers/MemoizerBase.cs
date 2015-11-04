using System;
using System.Collections.Generic;
using System.Threading;

namespace Funky
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <typeparam name="TCachedValue"></typeparam>
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
        public TValue GetOrInvoke(TKey key)
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

        protected abstract bool CheckCacheValue(TKey key);

        protected abstract TValue SetCacheValue(TKey key);

        protected abstract TValue GetCacheValue(TKey key);

        protected Dictionary<TKey, TCachedValue> Cache { get; private set; }

        protected ReaderWriterLockSlim CacheLock { get; }

        protected Func<TKey, TValue> Func { get; private set; }
    }
}