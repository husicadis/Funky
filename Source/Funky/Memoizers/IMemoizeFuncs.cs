namespace Funky
{
    public interface IMemoizeFuncs<in TKey, out TValue>
    {
        TValue GetOrInvoke(TKey key);
    }
}