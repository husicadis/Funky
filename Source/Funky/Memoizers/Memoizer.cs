using System;

namespace Funky
{
    public class Memoizer<T, TResult> : MemoizerBase<T, TResult, TResult>
    {
        public Memoizer(Func<T, TResult> func)
            : base(func)
        {
        }

        protected override TResult SetCacheValue(T key)
        {
            var value = Func(key);
            Cache.Add(key, value);
            return value;
        }

        protected override TResult GetCacheValue(T key)
        {
            return Cache[key];
        }

        protected override bool CheckCacheValue(T key)
        {
            return Cache.ContainsKey(key);
        }
    }
}