using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                .HasKey(s => s.SubjectID);

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(s => s.Period)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(s => s.Departments)
                .WithMany(d => d.Subjects)
                .UsingEntity(j => j.ToTable("DepartmentSubjects"));
        }
    }
}