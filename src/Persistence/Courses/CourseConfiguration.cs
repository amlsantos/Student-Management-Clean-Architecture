using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Courses;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).HasMaxLength(60);
        builder.Property(c => c.Credits).HasMaxLength(3);
        
        builder.HasData(SchoolDbInitializer.Courses);
    }
}