namespace api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

public class ApiDBContext : DbContext
{
    public ApiDBContext(DbContextOptions<ApiDBContext> options)
    : base(options)
    {
        
    }

    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}