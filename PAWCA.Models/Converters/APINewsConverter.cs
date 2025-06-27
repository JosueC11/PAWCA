using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Models.APIModels;
using PAWCA.Models.ViewModels;

namespace PAWCA.Models.Converters
{
    public class APINewsConverter
    {
        public static IEnumerable<News> NewsAPIToNews(APINewsResponse entity, bool isLoading)
        {
            if (isLoading)
            {
                return entity.Results.Select(news => new News
                {
                    ArticleId = news.ArticleId,
                    Title = news.Title,
                    Link = news.Link,
                    Description = news.Description,
                    PubDate = news.PubDate,
                    ImageUrl = news.ImageUrl,
                    Favorite = false,
                    Comment = string.Empty
                });
            }
            else
            {
                return entity.Results.Select(news => new News
                {
                    ArticleId = news.ArticleId,
                    Title = news.Title,
                    Link = news.Link,
                    Description = news.Description,
                    PubDate = news.PubDate,
                    ImageUrl = news.ImageUrl,
                    Favorite = true,
                    Comment = string.Empty
                });
            }          
        }
    }
}
