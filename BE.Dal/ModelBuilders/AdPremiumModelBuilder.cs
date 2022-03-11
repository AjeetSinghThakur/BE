using BE.Model;
using Microsoft.EntityFrameworkCore;

namespace BE.Dal.ModelBuilders
{
    public static class AdPremiumModelBuilder
    {
        public static void MapAdPremium(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdPremium>()
                .ToTable("AdPremium");

            modelBuilder.Entity<AdPremium>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<AdPremium>()
                .Property(e => e.Id)
                .HasColumnName("AdId");

            modelBuilder.Entity<AdPremium>()
                .HasOne(x => x.Location)
                .WithMany(x => x.AdPremium)
                .HasForeignKey(x => x.LocationsID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<AdPremium>()
                .HasOne(x => x.SubCategory)
                .WithMany(x => x.AdPremium)
                .HasForeignKey(x => x.SubcategoriesID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<AdPremium>()
                .Property(e => e.PremiumStart);

            modelBuilder.Entity<AdPremium>()
                .Property(e => e.PremiumEnd);
        }
    }
}
