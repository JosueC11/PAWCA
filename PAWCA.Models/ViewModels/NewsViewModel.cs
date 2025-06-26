using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWCA.Models.ViewModels
{
    public class NewsViewModel
    {
        public string ArticleId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Link { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime PubDate { get; set; }

        public string ImageUrl { get; set; } = null!;

        public bool Favorite { get; set; }

        public string Comment { get; set; } = null!;
    }
}
