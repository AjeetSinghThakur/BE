using BE.Dal.ModelBuilders;
using BE.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BE.Dal
{
    public class EntityDbContext : DbContext
    {
        private readonly string _connectionString;
        private IDbContextTransaction _transaction;

        public EntityDbContext() : base()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("Default");
        }

        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
        {
        }
        
        public DbSet<AdPremium> AdPremiums { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SubCategory> Subcategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.MapAdPremium();
            modelBuilder.MapLocation();
            modelBuilder.MapSubCategory();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public async Task BeginTransaction()
        {
            if (_transaction != null)
                return;
            
            _transaction = await Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (_transaction == null)
                return;
            
            await SaveChangesAsync();

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
        }

        public async Task Rollback()
        {
            if (_transaction == null)
                return;
            
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }
}
