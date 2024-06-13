using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{

    public DbSet<UserModel> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

}