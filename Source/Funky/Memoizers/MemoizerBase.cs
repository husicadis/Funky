using System;
using System.Collections.Generic;
using System.Threading;

namespace Funky
{
    public abstract class MemoizerBase<TArg, TResult, TCache> : IMemoizeFuncs<TArg, TResult>
    {
        protected MemoizerBase(Func<TArg, TResult> func)
            : this()
        {
            Func = func;
        }

        private MemoizerBase()
        {
            Cache = new Dictionary<TArg, TCache>();
            CacheLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }

        public TResult GetOrInvoke(TArg key)
        {
            TResult result;

            CacheLock.EnterWriteLock();
            try
            {
                result = ValueExists(key) ? GetCacheValue(key) : SetCacheValue(key);
            }
            finally
            {
                CacheLock.ExitWriteLock();
            }

            return result;
        }

        protected abstract TResult SetCacheValue(TArg key);

        protected abstract TResult GetCacheValue(TArg key);

        protected abstract bool ValueExists(TArg key);

        protected Dictionary<TArg, TCache> Cache { get; private set; }

        protected ReaderWriterLockSlim CacheLock { get; private set; }

        protected Func<TArg, TResult> Func { get; private set; }
    }
}