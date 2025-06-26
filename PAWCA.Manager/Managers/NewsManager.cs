using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Data.Repository.Interfaces;
using PAWCA.Manager.Managers.Interfaces;
using PAWCA.Models;

namespace PAWCA.Manager.Managers
{
    public class NewsManager : INewsManager
    {
        private readonly IRepositoryNews _repository;
        public NewsManager(IRepositoryNews repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            var allNews = await _repository.ReadAsync();
            var favoritesNews = allNews.Where(n => n.Favorite).ToList();
            return favoritesNews;
        }
        public async Task<News?> GetNewByIdAsync(string id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<bool> SaveNewAsync(News entity)
        {           
            var exists = await _repository.FindAsync(entity.ArticleId);
            if (exists != null) 
            {             
                exists.Comment = entity.Comment;
                return await _repository.UpdateAsync(exists);

            }
            entity.Favorite = true;
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> FavoriteEdit(News entity)
        {
            var exists = await _repository.FindAsync(entity.ArticleId);
            if (exists != null)
            {
                exists.Favorite = !exists.Favorite; 
                return await _repository.UpdateAsync(exists);
            }
            else
            {
                entity.Favorite = true;
                return await _repository.CreateAsync(entity);
            }          
        }

        public async Task<bool> DeleteNewAsync(string id)
        {
            var existsNew = await _repository.FindAsync(id);
            if (existsNew == null)
            {
                return false;
            }
            return await _repository.DeleteAsync(existsNew);
        }
    }
}
