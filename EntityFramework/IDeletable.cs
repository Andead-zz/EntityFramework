namespace Andead.Utils.EntityFramework
{
    /// <summary>
    ///     Defines properties for a softly deletable entity.
    /// </summary>
    public interface IDeletable
    {
        /// <summary>
        ///     Gets or sets whether the entity is deleted.
        /// </summary>
        bool IsDeleted { get; set; }
    }
}