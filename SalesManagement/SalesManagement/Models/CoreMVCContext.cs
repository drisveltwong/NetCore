using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesManagement.Models
{
    public partial class CoreMVCContext : DbContext
    {
        public CoreMVCContext()
        {
        }

        public CoreMVCContext(DbContextOptions<CoreMVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<SalesMan> SalesMan { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LENOVO-PF1L950N\\YXLOCALDB;Database=CoreMVC;User Id=sa;Password=123456Aa;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CreatedBY")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.MovieTitle)
                    .HasMaxLength(250)
                    .IsFixedLength();

                entity.Property(e => e.ReleasedDate)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UpdatedBY")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SalesMan>(entity =>
            {
                entity.HasKey(e => e.SalesManId);

                entity.Property(e => e.SalesManId).HasColumnName("SalesManID");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CreatedBY")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("UpdatedBY")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
