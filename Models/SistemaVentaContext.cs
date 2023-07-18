using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication3.Models
{
    public partial class SistemaVentaContext : DbContext
    {
        public SistemaVentaContext()
        {
        }

        public SistemaVentaContext(DbContextOptions<SistemaVentaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Detalleventa> Detalleventa { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Venta> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
 //               optionsBuilder.UseSqlServer("Server=DESKTOP-RM5GIKV\\SQLEXPRESS; DataBase=SistemaVenta;Integrated Security=true; Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Idcategoria)
                    .HasName("PK__categori__140587C738D78727");

                entity.ToTable("categoria");

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PK__cliente__7B86132F06FB2CFA");

                entity.ToTable("cliente");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<Detalleventa>(entity =>
            {
                entity.HasKey(e => e.Idnumdocumento)
                    .HasName("PK__detallev__484C382157B41071");

                entity.ToTable("detalleventa");

                entity.Property(e => e.Idnumdocumento)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idnumdocumento");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Serie)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("serie")
                    .IsFixedLength();

                entity.HasOne(d => d.IdnumdocumentoNavigation)
                    .WithOne(p => p.Detalleventum)
                    .HasForeignKey<Detalleventa>(d => d.Idnumdocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleve__idnum__4222D4EF");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detalleve__idpro__440B1D61");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PK__producto__DC53BE3C035850EB");

                entity.ToTable("producto");

                entity.Property(e => e.Idproducto).HasColumnName("idproducto");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__producto__idcate__412EB0B6");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__usuario__080A974373736D6B");

                entity.ToTable("usuario");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.Property(e => e.Contraseña).HasColumnName("contraseña");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.TipoUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo_usuario");

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.Idnumdocumento)
                    .HasName("PK__venta__484C3821619B654B");

                entity.ToTable("venta");

                entity.Property(e => e.Idnumdocumento).HasColumnName("idnumdocumento");

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("dni");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength();

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Serie)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("serie")
                    .IsFixedLength();

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__venta__idcliente__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
