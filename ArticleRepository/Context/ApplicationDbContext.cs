using ArticleRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleRepository.Context;

public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Article table accessor
    /// </summary>
    public DbSet<Article> Articles { get; set; }

    /// <summary>
    /// Default Constructor
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=App.db");
    }
}
