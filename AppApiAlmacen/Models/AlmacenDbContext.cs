using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppApiAlmacen.Models;

public partial class AlmacenDbContext : DbContext
{
    public AlmacenDbContext()
    {
    }

    public AlmacenDbContext(DbContextOptions<AlmacenDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tipousuario> Tipousuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbAlmacen;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tipousuario>(entity =>
        {
            entity.HasKey(e => e.IdTipo);

            entity.ToTable("tipousuario");

            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("tipoUsuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("apellidos");
            entity.Property(e => e.Celular)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("celular");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("clave");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.Foto)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("foto");
            entity.Property(e => e.IdTipousuario).HasColumnName("idTipousuario");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("nombres");
            entity.Property(e => e.TelefonoFijo)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("telefonoFijo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdTipousuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipousuario)
                .HasConstraintName("FK_usuario_tipousuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
