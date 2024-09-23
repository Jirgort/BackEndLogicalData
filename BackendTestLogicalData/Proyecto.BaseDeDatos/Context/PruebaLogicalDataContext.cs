using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto.BaseDeDatos.Context
{
    public partial class PruebaLogicalDataContext : DbContext
    {
        public PruebaLogicalDataContext()
        {
        }

        public PruebaLogicalDataContext(DbContextOptions<PruebaLogicalDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-QIOFV84\\SQLEXPRESS;Database=PruebaLogicalData;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.ToTable("Articulo", "Articulos");

                entity.HasIndex(e => e.Codigo, "UqArticuloCodigo")
                    .IsUnique();

                entity.Property(e => e.Codigo).HasMaxLength(25);

                entity.Property(e => e.Iva).HasColumnName("IVA");

                entity.Property(e => e.Nombre).HasMaxLength(25);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item", "Facturas");

                entity.HasComment("Almacena los items de las facturas del sistema.");

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkItemArticuloId");

                entity.HasOne(d => d.Orden)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.OrdenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkItemOrdenId");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden", "Facturas");

                entity.HasComment("Almacena las ordenes del sistema");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Ordens)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkOrdenUsuarioId");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario", "Usuarios");

                entity.HasComment("Almacena los usuarios del sistema.");

                entity.HasIndex(e => e.Nombre, "UqNombre")
                    .IsUnique();

                entity.Property(e => e.Apellido).HasMaxLength(25);

                entity.Property(e => e.Contrasenia).HasMaxLength(64);

                entity.Property(e => e.Nombre).HasMaxLength(25);

                entity.Property(e => e.Username).HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
