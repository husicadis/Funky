namespace Funky
{
    /// <summary>
    /// Defines the methodsneeded to implement a Memoizer.
    /// </summary>
    /// <typeparam name="TKey">The type of memoizer's keys.</typeparam>
    /// <typeparam name="TValue">The type of the memoizer's return values.</typeparam>
    public interface IMemoizeThings<in TKey, out TValue>
    {
        /// <summary>
        /// Gets or adds a key/value pair from the memoizer if it already exists.  Adds a key/value pair to the memoizer if it does not already exist.
        /// </summary>
        /// <param name="key">The key of the element to get or add.</param>
        /// <returns>The value for the key.  This will be either the existing value for the key if the key is already in the memoizer, or the new value if the key was not in the memoizer.</returns>
        TValue GetOrAdd(TKey key);
    }
}