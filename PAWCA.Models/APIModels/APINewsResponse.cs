using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PAWCA.Models.APIModels
{
    public class APINewsResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("results")]
        public List<News> Results { get; set; } = new();
    }
}
