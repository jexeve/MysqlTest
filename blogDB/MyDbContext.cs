using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Database=posts;User Id=root;Password=", new MySqlServerVersion(new Version(8, 0, 25)));
    }
}
