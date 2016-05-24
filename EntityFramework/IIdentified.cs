using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andead.Utils.EntityFramework
{
    /// <summary>
    ///     Defines basic fields for an identified entity.
    /// </summary>
    /// <typeparam name="TKey">
    ///     When using <see cref="Guid" /> as the identity column type, you should explicitly mark the <see cref="Id" />
    ///     property with a <see cref="DatabaseGeneratedAttribute" /> with <see cref="DatabaseGeneratedOption.Identity" />
    ///     for it to become an identity column.
    /// </typeparam>
    public interface IIdentified<TKey>
        where TKey : struct, IComparable<TKey>
    {
        /// <summary>
        ///     Id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        TKey Id { get; set; }
    }
}