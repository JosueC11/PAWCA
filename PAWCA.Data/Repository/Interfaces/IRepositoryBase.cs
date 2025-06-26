using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWCA.Data.Repository.Interfaces
{
    /// <summary>
    /// Interface for basic repository operations.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Creates a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be created.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        Task<bool> CreateAsync(T entity);

        /// <summary>
        /// Deletes an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// Reads all entities of type T asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of entities.</returns>
        Task<IEnumerable<T>> ReadAsync();

        /// <summary>
        /// Finds an entity from the list of objects
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Entity by id</returns>
        Task<T?> FindAsync(string id);

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating success.</returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Checks if an entity exists asynchronously.
        /// </summary>
        /// <param name="entity">The entity to check for existence.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a boolean indicating if the entity exists.</returns>
        Task<bool> ExistsAsync(T entity);
    }
}
