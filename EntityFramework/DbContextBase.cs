using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Andead.Utils.EntityFramework
{
    public abstract class DbContextBase : DbContext
    {
        /// <summary>
        ///     Sets <see cref="IDeletable.IsDeleted" /> to true.
        /// </summary>
        /// <param name="deletable">An instance of <see cref="IDeletable" />.</param>
        public void Delete(IDeletable deletable)
        {
            deletable.IsDeleted = true;
        }

        /// <summary>
        ///     Sets <see cref="IDeletable.IsDeleted" /> to false.
        /// </summary>
        /// <param name="deletable">An instance of <see cref="IDeletable" />.</param>
        public void Undelete(IDeletable deletable)
        {
            deletable.IsDeleted = false;
        }

        /// <summary>
        ///     Saves pending changes to the database with empty string as an author and <see cref="DateTime.Now" /> as a timestamp.
        /// </summary>
        /// <returns>The number of state entries written to the underlying database. (See <see cref="DbContext.SaveChanges" />). </returns>
        public override int SaveChanges()
        {
            return SaveChanges(string.Empty);
        }

        /// <summary>
        ///     Saves pending changes to the database with a given author and <see cref="DateTime.Now" /> as a content for
        ///     <see cref="ITracked" /> fields.
        /// </summary>
        /// <param name="author">The user's name.</param>
        /// <returns>The number of state entries written to the underlying database. (See <see cref="DbContext.SaveChanges" />). </returns>
        public int SaveChanges(string author)
        {
            return SaveChanges(author, DateTime.Now);
        }

        /// <summary>
        ///     Saves pending changes to the database with a given author.
        /// </summary>
        /// <param name="author">The user's name.</param>
        /// <param name="timestamp">The timestamp for <see cref="ITracked" />.</param>
        /// <returns>The number of state entries written to the underlying database. (See <see cref="DbContext.SaveChanges" />). </returns>
        public virtual int SaveChanges(string author, DateTime timestamp)
        {
            foreach (DbEntityEntry entry in ChangeTracker.Entries())
            {
                var tracked = entry.Entity as ITracked;

                switch (entry.State)
                {
                    case EntityState.Detached:
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Added:
                        if (tracked != null)
                        {
                            tracked.Created = timestamp;
                            tracked.CreatedBy = author;
                        }
                        break;
                    case EntityState.Deleted:
                        if (entry.Entity is IDeletable)
                        {
                            throw new InvalidOperationException(
                                "Attempted to set Deleted state for an entity which should be deleted softly.");
                        }
                        break;
                    case EntityState.Modified:
                        if (tracked != null)
                        {
                            tracked.Updated = timestamp;
                            tracked.UpdatedBy = author;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return base.SaveChanges();
        }

        #region ctors

        protected DbContextBase()
        {
        }

        protected DbContextBase(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        protected DbContextBase(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        protected DbContextBase(ObjectContext objectContext, bool dbContextOwnsObjectContext)
            : base(objectContext, dbContextOwnsObjectContext)
        {
        }

        #endregion
    }
}