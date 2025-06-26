using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Models;

namespace PAWCA.Manager.Managers.Interfaces
{
    public interface INewsManager
    {
        Task<IEnumerable<News>> GetAllNewsAsync();
        Task<bool> SaveNewAsync(News entity);
        Task<bool> DeleteNewAsync(string id);
        Task<News?> GetNewByIdAsync(string id);
        Task<bool> FavoriteEdit(News entity);
    }
}
