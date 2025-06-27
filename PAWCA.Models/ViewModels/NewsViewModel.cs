using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWCA.Models.ViewModels
{
    public class NewsViewModel
    {
        public string ArticleId { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public DateTime PubDate { get; set; }

        public string ImageUrl { get; set; }

        public bool Favorite { get; set; }

        public string Comment { get; set; }
    }
}
