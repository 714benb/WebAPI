using Microsoft.EntityFrameworkCore;
using WebAPI.API.Domain.Models;

namespace WebAPI.API.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<XEntity> XEntities {get;set;}
        public DbSet<YEntity> YEntities {get; set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<XEntity>().ToTable("XEntities");
            builder.Entity<XEntity>().HasKey(p => p.Id);
            builder.Entity<XEntity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<XEntity>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<XEntity>().HasMany(p => p.YEntities).WithOne(p => p.XEntity).HasForeignKey(p => p.XEntityId);
            builder.Entity<XEntity>().HasData
            (
                new XEntity { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
                new XEntity { Id = 101, Name = "Dairy" }
            );

            builder.Entity<YEntity>().ToTable("YEntities");
            builder.Entity<YEntity>().HasKey(p => p.Id);
            builder.Entity<YEntity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<YEntity>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<YEntity>().Property(p => p.QuantityInPackage).IsRequired();

        }
    }
}