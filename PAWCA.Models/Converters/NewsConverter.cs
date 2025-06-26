using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAWCA.Models.ViewModels;

namespace PAWCA.Models.Converters
{
    public class NewsConverter
    {
        public static NewsViewModel NewsToNewsViewModel(News entity)
        {
            return new NewsViewModel
            {
                ArticleId = entity.ArticleId,
                Title = entity.Title,
                Link = entity.Link,
                Description = entity.Description,
                PubDate = entity.PubDate,
                ImageUrl = entity.ImageUrl,
                Favorite = entity.Favorite,
                Comment = entity.Comment
            };
        }

        public static News NewsViewModelToNews(NewsViewModel model)
        {
            return new News
            {
                ArticleId = model.ArticleId,
                Title = model.Title,
                Link = model.Link,
                Description = model.Description,
                PubDate = model.PubDate,
                ImageUrl = model.ImageUrl,
                Favorite = model.Favorite,
                Comment = model.Comment
            };
        }
    }
}
