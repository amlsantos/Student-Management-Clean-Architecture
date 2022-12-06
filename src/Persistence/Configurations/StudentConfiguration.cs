using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name).HasMaxLength(50);
        builder.Property(s => s.Email).HasMaxLength(50);

        builder.HasMany<Enrollment>(s => s.Enrollments).WithOne(e => e.Student);
        builder.HasMany<Disenrollment>(s => s.Disenrollments).WithOne(e => e.Student);

        builder.HasData(StudentDbInitializer.Students);
    }
}