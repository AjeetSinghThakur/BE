using BE.Model;
using Microsoft.EntityFrameworkCore;

namespace BE.Dal.ModelBuilders
{
    public static class LocationModelBuilder
    {
        public static void MapLocation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .ToTable("Locations");

            modelBuilder.Entity<Location>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<Location>()
                .Property(e => e.Name)
                .IsRequired();
        }
    }
}
