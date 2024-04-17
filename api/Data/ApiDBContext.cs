using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class ApiDBContext : IdentityDbContext<AppUser>
{
    public ApiDBContext(DbContextOptions<ApiDBContext> options)
    : base(options)
    {

    }

    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles = new List<IdentityRole>{
            new IdentityRole 
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole 
            {
                Name = "User",
                NormalizedName = "USER"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}