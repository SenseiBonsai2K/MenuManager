using MenuManager.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuManager.Models.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder) {
            builder.ToTable("Dish");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(d => d.Price).
                IsRequired();
            builder.HasOne(d => d.Type)
                .WithMany(t => t.Dishes)
                .HasForeignKey(d => d.TypeId);
        }
    }
}
