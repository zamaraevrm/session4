using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace session4
{
    public partial class session4DBContext : DbContext
    {
        public session4DBContext()
        {
        }

        public session4DBContext(DbContextOptions<session4DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialsSupplier> MaterialsSuppliers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data source=session4DB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.NameMaterial);

                entity.Property(e => e.NameMaterial)
                    .HasColumnType("TEXT (255)")
                    .HasColumnName("Name_material");

                entity.Property(e => e.MinQuantity)
                    .HasColumnType("INT")
                    .HasColumnName("Min_quantity");

                entity.Property(e => e.Price).HasColumnType("DECIMAL");

                entity.Property(e => e.Quantity).HasColumnType("INT");

                entity.Property(e => e.QuantityInThePackeg)
                    .HasColumnType("INT")
                    .HasColumnName("Quantity_in_the_packeg");

                entity.Property(e => e.TypeMaterial)
                    .IsRequired()
                    .HasColumnName("Type_material");

                entity.Property(e => e.UnitOfMeasurement)
                    .HasColumnType("TEXT (3)")
                    .HasColumnName("Unit_of_measurement");

                entity.Property(e => e.UrlImage).HasColumnName("URL_image");
            });

            modelBuilder.Entity<MaterialsSupplier>(entity =>
            {
                entity.HasKey(e => new { e.Material, e.Supplier });

                entity.Property(e => e.Material).HasColumnType("text");

                entity.Property(e => e.Supplier).HasColumnType("text");

                entity.HasOne(d => d.MaterialNavigation)
                    .WithMany(p => p.MaterialsSuppliers)
                    .HasForeignKey(d => d.Material)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SupplierNavigation)
                    .WithMany(p => p.MaterialsSuppliers)
                    .HasForeignKey(d => d.Supplier)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Supplier1);

                entity.Property(e => e.Supplier1).HasColumnName("Supplier");

                entity.Property(e => e.Inn)
                    .HasColumnType("TEXT (10)")
                    .HasColumnName("INN");

                entity.Property(e => e.RatingOfQuality)
                    .HasColumnType("INT")
                    .HasColumnName("Rating_of_quality");

                entity.Property(e => e.StartDateOfWorkWithTheSupplier)
                    .HasColumnType("DATE")
                    .HasColumnName("Start_date_of_work_with_the_supplier");

                entity.Property(e => e.TypeSupplier)
                    .HasColumnType("TEXT (3)")
                    .HasColumnName("Type_supplier");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
