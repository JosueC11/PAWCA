using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;
using PAWCA.Models.Converters;

namespace PAWCA.Models;

public partial class News
{
    [JsonPropertyName("article_id")]
    public string ArticleId { get; set; } = null!;

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    [JsonPropertyName("link")]
    public string Link { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("pubDate")]
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime PubDate { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonIgnore]
    public bool Favorite { get; set; }
    [JsonIgnore]
    public string Comment { get; set; } = null!;
}
