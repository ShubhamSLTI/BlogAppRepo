using BlogAppAPI.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Users> Users { get; set; }
    public DbSet<UserBlogs> UserBlogs { get; set; }
    public DbSet<BlogComments> BlogComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure the DbContext to use a specific database provider and connection string.
        optionsBuilder.UseSqlServer("Server=92RZXS3\\SQLEXPRESS;Database=BlogAppDB;Integrated Security=True;Encrypt=False;");
    }
}
