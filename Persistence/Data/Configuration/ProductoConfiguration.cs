using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
        {
            public void Configure(EntityTypeBuilder<Producto> builder)
            {
                builder.ToTable("producto");
    
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id);

                builder.Property(e => e.Nombre)
                .HasColumnName("nombre")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

                builder.Property(e => e.Precio)
                .HasColumnName("precio")
                .HasColumnType("decimal(18,2)")
                .HasMaxLength(50)
                .IsRequired();

                builder.Property(e => e.FechaCreacion)
                .HasColumnName("fechaCreacion")
                .HasColumnType("DateTime")
                .HasMaxLength(50)
                .IsRequired();

                builder.HasOne(p => p.Marca)
                .WithMany(p => p.Productos)
                .HasForeignKey(p => p.MarcaId);

                builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Productos)
                .HasForeignKey(p => p.CategoriaId);
            }
        }
}