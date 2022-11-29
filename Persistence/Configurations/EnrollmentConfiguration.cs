using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne<Student>(e => e.Student).WithMany(s => s.Enrollments);
        builder.HasOne<Course>(e => e.Course);
        
        builder.HasData(DbInitializer.Enrollments);
    }
}