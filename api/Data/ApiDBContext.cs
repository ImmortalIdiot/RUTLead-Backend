using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApiDBContext : DbContext
{
    public ApiDBContext(DbContextOptions<ApiDBContext> options)
    : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }
}