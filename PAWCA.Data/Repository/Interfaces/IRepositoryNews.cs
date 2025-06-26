using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Models;

namespace PAWCA.Data.Repository.Interfaces
{
    public interface IRepositoryNews
    {
        Task<bool> CreateAsync(News entity);
        Task<bool> DeleteAsync(News entity);
        Task<IEnumerable<News>> ReadAsync();
        Task<News?> FindAsync(string id);
        Task<bool> UpdateAsync(News entity);
        Task<bool> ExistsAsync(News entity);
    }
}
