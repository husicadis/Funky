using System;
using System.Threading;

namespace Funky
{
    internal static class ReaderWriterLockSlimExtensions
    {
        public static TResult InvokeWithWriteLock<TResult>(this ReaderWriterLockSlim locker, Func<TResult> func)
        {
            locker.EnterWriteLock();
            try
            {
                return func();
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
