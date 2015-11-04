namespace Funky
{
    /// <summary>
    /// Allows an object to implement a Memoizer.
    /// </summary>
    /// <typeparam name="TKey">The type of memoizer's keys.</typeparam>
    /// <typeparam name="TValue">The type of the memoizer's stored values.</typeparam>
    public interface IMemoizeThings<in TKey, out TValue>
    {
        TValue GetOrInvoke(TKey key);
    }
}