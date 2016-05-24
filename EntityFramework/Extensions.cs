using System;
using System.Collections.Generic;

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

        /// <summary>
        ///     Adds children objects to <see cref="IHierarchical{T}.Children" /> collection of a given instance of
        ///     <see cref="IHierarchical{T}" />.
        /// </summary>
        /// <typeparam name="T">Hierarchical object type.</typeparam>
        /// <param name="current">Parent object.</param>
        /// <param name="children">Children objects.</param>
        public static T AddChildren<T>(this T current, params T[] children)
            where T : class, IHierarchical<T>
        {
            if (current.Children == null)
            {
                current.Children = new List<T>();
            }

            foreach (T child in children)
            {
                current.Children.Add(child);
                child.Parent = current;
            }

            return current;
        }
    }
}