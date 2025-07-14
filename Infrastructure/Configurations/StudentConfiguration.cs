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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(s => s.StudID);

            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(s => s.Phone)
                .IsRequired()
                .HasMaxLength(15);

            builder
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}