using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
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