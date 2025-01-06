using MenuManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuManager.Models.Configurations
{
    public class DishTypeConfiguration : IEntityTypeConfiguration<DishType>
    {
        public void Configure(EntityTypeBuilder<DishType> builder) {
            builder.ToTable("DishType");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Type)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
