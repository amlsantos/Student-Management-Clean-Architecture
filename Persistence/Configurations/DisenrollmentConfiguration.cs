using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Entities;

namespace Persistence.Configurations;

public class DisenrollmentConfiguration : IEntityTypeConfiguration<Disenrollment>
{
    public void Configure(EntityTypeBuilder<Disenrollment> builder)
    {
        builder.HasKey(d => d.Id);
        builder.HasOne<Student>(d => d.Student).WithMany(s => s.Disenrollments);
        builder.HasOne<Course>(d => d.Course);
    }
}