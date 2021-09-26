using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SureSuccessApp.Domain.Entities;

namespace SureSuccessApp.Infrastructure.SchemaDefinitions
{
    public class StudentEntitySchemaConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student", AppDbContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .HasColumnName("FIRST_NAME")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .HasColumnName("LAST_NAME")
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}