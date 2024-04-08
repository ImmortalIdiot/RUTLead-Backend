using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);

            builder.Property(s => s.Email)
                   .IsRequired();

            builder.Property(s => s.FullName)
                   .IsRequired();

            builder.Property(s => s.Password)
                   .IsRequired();
        }
    }
}
