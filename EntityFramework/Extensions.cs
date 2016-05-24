using System;

namespace Andead.Utils.EntityFramework
{
    /// <summary>
    ///     Provides common methods for entities.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        ///     Returns true if <paramref name="identified" /> has default <see cref="IIdentified{TId}.Id" /> (equals zero).
        /// </summary>
        /// <param name="identified"></param>
        public static bool IsTransient<TKey>(this IIdentified<TKey> identified)
            where TKey : struct, IComparable<TKey>
        {
            return default(TKey).CompareTo(identified.Id) == 0;
        }
    }
}