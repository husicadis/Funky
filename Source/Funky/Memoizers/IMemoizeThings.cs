namespace Funky
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IMemoizeThings<in TKey, out TValue>
    {
        TValue GetOrInvoke(TKey key);
    }
}