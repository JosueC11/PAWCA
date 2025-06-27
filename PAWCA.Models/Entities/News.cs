using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;
using PAWCA.Models.Converters;
using PAWCA.Models.Entities;

namespace PAWCA.Models;

public partial class News : Entity
{
    [Key]
    [Column("article_id")]
    [JsonPropertyName("article_id")]
    public string ArticleId { get; set; } = null!;

    [Column("title")]
    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    [Column("link")]
    [JsonPropertyName("link")]
    public string Link { get; set; } = null!;

    [Column("description")]
    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [Column("pubDate")]
    [JsonPropertyName("pubDate")]
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime PubDate { get; set; }

    [Column("image_url")]
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [Column("favorite")]
    [JsonPropertyName("favorite")]
    public bool Favorite { get; set; }

    [Column("comment")]
    [JsonPropertyName("comment")]
    public string Comment { get; set; } = null!;
}
