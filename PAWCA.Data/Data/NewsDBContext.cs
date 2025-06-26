using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PAWCA.Models;

namespace PAWCA.Data.Data;

public partial class NewsDBContext : DbContext
{
    public NewsDBContext()
    {
    }

    public NewsDBContext(DbContextOptions<NewsDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<News> News { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KM9AHJM\\SQLEXPRESS;Database=PAWCADB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.ArticleId);

            entity.Property(e => e.ArticleId)
                .HasMaxLength(100)
                .HasColumnName("article_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(1000)
                .HasColumnName("comment");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Favorite).HasColumnName("favorite");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.Link)
                .HasMaxLength(255)
                .HasColumnName("link");
            entity.Property(e => e.PubDate)
                .HasColumnType("datetime2")
                .HasColumnName("pubDate");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
