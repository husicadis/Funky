using System;

namespace Funky
{
    public class Memoizer<TKey, TValue> : MemoizerBase<TKey, TValue, TValue>
    {
        public Memoizer(Func<TKey, TValue> func)
            : base(func)
        {
        }

        protected override TValue SetCacheValue(TKey key)
        {
            var value = Func(key);
            Cache.Add(key, value);
            return value;
        }

        protected override TValue GetCacheValue(TKey key)
        {
            return Cache[key];
        }

        protected override bool CheckCacheValue(TKey key)
        {
            return Cache.ContainsKey(key);
        }
    }
}