using Microsoft.EntityFrameworkCore;

namespace api.Data;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class ApiDBContext : IdentityDbContext<AppUser>
{
    public ApiDBContext(DbContextOptions<ApiDBContext> options)
    : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }
}