using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Architecture;
using PAWCA.Architecture.Providers;
using PAWCA.Models;
using PAWCA.Models.APIModels;
using PAWCA.Models.Converters;
using PAWCA.Service.Services.Interfaces;

namespace PAWCA.Service.Services
{
    public class NewsService : INewsService
    {
        private readonly IRestProvider _restProvider;
        public NewsService(IRestProvider restProvider) 
        {
            _restProvider = restProvider;
        }
        public async Task<News> GetNewByIdAsync(string id)
        {
            var result = await _restProvider.GetAsync("https://localhost:7264/NewsAPI/", id);
            var entity = await JsonProvider.DeserializeAsync<News>(result);
            return entity;

        }
        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            var result = await _restProvider.GetAsync("https://localhost:7264/NewsAPI/", null);
            var entities = await JsonProvider.DeserializeAsync<IEnumerable<News>>(result);
            return entities;
        }

        public async Task<IEnumerable<News>> GetAllNewsServiceAsync(bool isLoading)
        {
            var result = await _restProvider.GetAsync("https://newsdata.io/api/1/latest?apikey=pub_b31590d324fa46aca7bad9c3d365bccf", null);
            var entities = await JsonProvider.DeserializeAsync<APINewsResponse>(result);
            var news = APINewsConverter.NewsAPIToNews(entities, isLoading);
            return news;
        }

        public async Task<bool> DeleteNewAsync(string id)
        {
            var result = await _restProvider.DeleteAsync("https://localhost:7264/NewsAPI/", id);
            return true;
        }

        public async Task<bool> SaveNewAsync(IEnumerable<News> entities)
        {
            var content = JsonProvider.Serialize(entities);
            var result = await _restProvider.PostAsync("https://localhost:7264/NewsAPI/", content);
            return true;
        }

        public async Task<bool> FavoriteEdit(IEnumerable<News> entities)
        {
            var content = JsonProvider.Serialize(entities);
            var result = await _restProvider.PostAsync($"https://localhost:7264/NewsAPI/Favorite", content);
            return true;
        }

        public async Task<IEnumerable<News>> ValidateFavorite()
        {
            var FavoritesNews = await GetAllNewsAsync(); 
            var allNewsService = await GetAllNewsServiceAsync(true);

            var favoriteIds = FavoritesNews.Select(f => f.ArticleId).ToHashSet();

            foreach (var newsItem in allNewsService)
            {
                if (favoriteIds.Contains(newsItem.ArticleId))
                {
                    newsItem.Favorite = true;
                }
            }
            return allNewsService;
        }
    }
}
