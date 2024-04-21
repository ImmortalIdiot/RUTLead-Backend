namespace api.Data;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        List<IdentityRole> roles = new List<IdentityRole> {
            new IdentityRole 
            {
                Name = "Monitor",
                NormalizedName = "MONITOR"
            },
            new IdentityRole 
            {
                Name = "Student",
                NormalizedName = "STUDENT"
            },
            new IdentityRole 
            {
                Name = "GroupLeader",
                NormalizedName = "GROUPLEADER"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}