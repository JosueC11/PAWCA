using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAWCA.Data.Data;
using PAWCA.Data.Repository.Interfaces;

namespace PAWCA.Data.Repository
{
    /// <summary>
    /// Base class for repository operations.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly NewsDBContext _context;
        protected NewsDBContext DbContext => _context;
        protected DbSet<T> DbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        public RepositoryBase()
        {
            _context = new NewsDBContext();
            DbSet<T> _sdbSet = _context.Set<T>();
        }

        /// <summary>
        /// Creates an entity of type T asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be saved in the database.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new PAWCAException(ex);
            }
        }

        /// <summary>
        /// Updates an existing entity of type T asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new PAWCAException(ex);
            }
        }

        /// <summary>
        /// Deletes an entity of type T asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _context.Remove(entity);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new PAWCAException(ex);
            }
        }

        /// <summary>
        /// Reads all entities of type T asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
        public async Task<IEnumerable<T>> ReadAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new PAWCAException(ex);
            }
        }

        /// <summary>
        /// Reads an entity of type T asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
        public async Task<T?> FindAsync(string id)
        {
            try
            {
                var entities = await _context.Set<T>().FindAsync(id);
                return entities;
            }
            catch (Exception ex)
            {
                throw new PAWCAException(ex);
            }
        }

        /// <summary>
        /// Checks if an entity of type T exists asynchronously.
        /// </summary>
        /// <param name="entity">The entity to check for existence.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating if the entity exists.</returns>
        public async Task<bool> ExistsAsync(T entity)
        {
            try
            {
                var items = await ReadAsync();
                return items.Any(x => x.Equals(entity));
            }
            catch (Exception ex)
            {
                throw new PAWCAException(ex);
            }
        }

        /// <summary>
        /// Saves changes to the database asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        protected async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
