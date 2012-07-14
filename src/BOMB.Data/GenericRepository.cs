namespace BOMB.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// A Generic Repositry for EF
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class GenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The DB Context
        /// </summary>
        private BombContext context;

        /// <summary>
        /// The entity we are working with
        /// </summary>
        private DbSet<TEntity> dbset;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository&lt;TEntity&gt;"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(BombContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
        }

        /// <summary>
        /// Gets the specified include properties.
        /// </summary>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>returns an IQueryable of TEntity</returns>
        public virtual IQueryable<TEntity> Get(string includeProperties = "")
        {
            IQueryable<TEntity> query = this.dbset;

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        /// <summary>
        /// Gets the by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>returns a TEntity</returns>
        public virtual TEntity GetByID(object id)
        {
            return this.dbset.Find(id);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TEntity entity)
        {
            this.dbset.Add(entity);
        }

        /// <summary>
        /// Deletes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.dbset.Find(id);
            this.Delete(entityToDelete);
        }

        /// <summary>
        /// Deletes the specified entity to delete.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (this.context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.dbset.Attach(entityToDelete);
            }

            this.dbset.Remove(entityToDelete);
        }

        /// <summary>
        /// Updates the specified entity to update.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        public virtual void Update(TEntity entityToUpdate)
        {
            this.dbset.Attach(entityToUpdate);
            this.context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
