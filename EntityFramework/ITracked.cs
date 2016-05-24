using System;

namespace Andead.Utils.EntityFramework
{
    /// <summary>
    ///     Defines properties for tracking changes to the entity.
    /// </summary>
    public interface ITracked
    {
        /// <summary>
        ///     The date and time of creation.
        /// </summary>
        DateTime? Created { get; set; }

        /// <summary>
        ///     The creator of entity.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        ///     The date and time of updating.
        /// </summary>
        DateTime? Updated { get; set; }

        /// <summary>
        ///     The user who updated the entity.
        /// </summary>
        string UpdatedBy { get; set; }
    }
}