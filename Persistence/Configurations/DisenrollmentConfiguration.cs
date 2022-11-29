using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagementSystem.Entities;

namespace Persistence.Configurations;

public class DisenrollmentConfiguration : IEntityTypeConfiguration<Disenrollment>
{
    public void Configure(EntityTypeBuilder<Disenrollment> builder)
    {
        builder.HasKey(d => d.Id);
    }
}