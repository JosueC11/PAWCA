using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Models;

namespace PAWCA.Service.Services.Interfaces
{
    public interface INewsService
    {
        Task<News> GetNewByIdAsync(string id);
        Task<IEnumerable<News>> GetAllNewsAsync();
        Task<IEnumerable<News>> GetAllNewsServiceAsync(bool isLoading);
        Task<bool> DeleteNewAsync(string id);
        Task<bool> SaveNewAsync(IEnumerable<News> entities);
        Task<IEnumerable<News>> ValidateFavorite();
        Task<bool> FavoriteEdit(IEnumerable<News> entity);
    }
}
