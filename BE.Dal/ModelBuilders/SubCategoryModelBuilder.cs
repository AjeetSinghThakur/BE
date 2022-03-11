using BE.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BE.Dal.ModelBuilders
{
    public static class SubCategoryModelBuilder
    {
        public static void MapSubCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategory>()
                .ToTable("Subcategories");

            modelBuilder.Entity<SubCategory>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.Name)
                .IsRequired();
        }
    }
}
