using Microsoft.EntityFrameworkCore;
using Shapes3D.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.DAL.Context
{
    public class StereometryContext : DbContext
    {
        public StereometryContext(DbContextOptions<StereometryContext> options)
        : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<RegularUser> RegularUsers { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<ShapeType> ShapeTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Admin>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

            builder.Entity<RegularUser>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

            builder.Entity<ShapeType>()
                .HasIndex(i => i.Id)
                .IsUnique(true);

            builder.Entity<Shape>()
                .HasIndex(i => i.Id)
                .IsUnique(true);
        }
    }
}
