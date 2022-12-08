using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Enrollments;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.StudentId).IsRequired();
        builder.HasOne(e => e.Student).WithMany(s => s.Enrollments);
        
        builder.Property(e => e.CourseId).IsRequired();
        builder.HasOne(e => e.Course);
        
        builder.HasData(SchoolDbInitializer.Enrollments);
    }
}