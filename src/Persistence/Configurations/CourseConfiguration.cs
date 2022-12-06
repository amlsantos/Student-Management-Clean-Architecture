using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;
using StudentManagementSystem;
using StudentManagementSystem.Entities;

namespace Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(30);
        builder.Property(c => c.Credits).HasMaxLength(3);
        
        builder.HasData(StudentDbInitializer.Courses);
    }
}