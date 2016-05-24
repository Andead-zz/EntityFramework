using System.Collections.Generic;

namespace Andead.Utils.EntityFramework
{
    /// <summary>
    ///     Supports children and parents.
    /// </summary>
    /// <typeparam name="T">Hierarchical object type.</typeparam>
    public interface IHierarchical<T> 
        where T : class, IHierarchical<T>
    {
        /// <summary>
        ///     Returns the parent object.
        /// </summary>
        T Parent { get; set; }

        /// <summary>
        ///     Returns the collection of children objects.
        /// </summary>
        ICollection<T> Children { get; set; }
    }
}