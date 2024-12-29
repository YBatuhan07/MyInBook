using Microsoft.EntityFrameworkCore;
using MyInBook.Core.MyEntities;

namespace MyInBook.Data;

public class MyInBookDatabaseContext : DbContext
{

    public MyInBookDatabaseContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
}
