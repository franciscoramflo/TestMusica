using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musica.Data.Repositories
{
    public class GenericRepository<TEntity>
       where TEntity : class
    {
        protected MusicaDBContext _context;
        protected DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the GenericRepository class.
        /// </summary>
        public GenericRepository(MusicaDBContext context)
        {
            if (context == null)
                throw new ArgumentNullException("unitOfWork", "Container cannot be null");
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        #region IRepository<TEntity> Members

        /// <summary>
        /// <see cref="Project.Interfaces.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="entity"><see cref="Project.Interfaces.IRepository{TEntity}"/></param>
        public virtual void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.Add(entity);
        }


        /// <summary>
        /// <see cref="Project.Interfaces.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="entity"><see cref="Project.Interfaces.IRepository{TEntity}"/></param>
        public virtual void Modify(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }


        /// <summary>
        /// <see cref="Project.Interfaces.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="id"><see cref=""/></param>
        public virtual void Remove(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            TEntity entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
        }


        /// <summary>
        /// <see cref="Project.Interfaces.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="entity"><see cref="Project.Interfaces.IRepository{TEntity}"/></param>
        public virtual void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }


        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <returns><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;

            return query;
        }

        /// <summary>
        /// <see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/>
        /// </summary>
        /// <param name="predicate"><see cref="Project.Interfaces.IRepository{TEntity}"/></param>
        /// <returns><see cref="Microsoft.Samples.NLayerApp.Domain.Core.IRepository{TEntity}"/></returns>
        public virtual IQueryable<TEntity> GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        public IQueryable<TEntity> GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params System.Linq.Expressions.Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (query != null)
                query = query.Where(predicate);

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => EntityFrameworkQueryableExtensions.Include(current, include));

            return query;
        }

        #endregion

        #region Implementacion de IDisposable

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        //public static implicit operator GenericRepository<TEntity>(GenericRepository<Crop> v)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
