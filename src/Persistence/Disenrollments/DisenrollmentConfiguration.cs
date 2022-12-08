using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Disenrollments;

public class DisenrollmentConfiguration : IEntityTypeConfiguration<Disenrollment>
{
    public void Configure(EntityTypeBuilder<Disenrollment> builder)
    {
        builder.HasKey(d => d.Id);
        
        builder.HasOne(d => d.Student).WithMany(s => s.Disenrollments);
        builder.HasOne(d => d.Course);
    }
}