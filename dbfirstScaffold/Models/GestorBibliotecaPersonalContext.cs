using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dbfirstScaffold.Models;

public partial class GestorBibliotecaPersonalContext : DbContext
{
    public GestorBibliotecaPersonalContext()
    {
    }

    public GestorBibliotecaPersonalContext(DbContextOptions<GestorBibliotecaPersonalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acceso> Accesos { get; set; }

    public virtual DbSet<GbpAlmCatLibro> GbpAlmCatLibros { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=gestorBibliotecaPersonal;Username=postgres;Password=_altair458");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acceso>(entity =>
        {
            entity.HasKey(e => e.IdAcceso).HasName("Accesos_pkey");

            entity.ToTable("Accesos", "gbp_operacional");

            entity.Property(e => e.IdAcceso).HasColumnName("id_acceso");
            entity.Property(e => e.CodigoAcceso)
                .HasColumnType("character varying")
                .HasColumnName("codigo_acceso");
            entity.Property(e => e.DescripcionAcceso)
                .HasColumnType("character varying")
                .HasColumnName("descripcion_acceso");
        });

        modelBuilder.Entity<GbpAlmCatLibro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("gbp_alm_cat_libros_pkey");

            entity.ToTable("gbp_alm_cat_libros", "gbp_operacional");

            entity.Property(e => e.IdLibro).HasColumnName("id_libro");
            entity.Property(e => e.Autor)
                .HasColumnType("character varying")
                .HasColumnName("autor");
            entity.Property(e => e.Edicion).HasColumnName("edicion");
            entity.Property(e => e.Isbn).HasColumnName("isbn");
            entity.Property(e => e.Titulo)
                .HasColumnType("character varying")
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.ToTable("libro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Autor).HasColumnName("autor");
            entity.Property(e => e.Edicion).HasColumnName("edicion");
            entity.Property(e => e.Isbn).HasColumnName("isbn");
            entity.Property(e => e.Titulo).HasColumnName("titulo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("Usuarios_pkey");

            entity.ToTable("Usuarios", "gbp_operacional");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.ApellidoUsuario)
                .HasColumnType("character varying")
                .HasColumnName("apellido_usuario");
            entity.Property(e => e.ClaveUsuario)
                .HasColumnType("character varying")
                .HasColumnName("clave_usuario");
            entity.Property(e => e.DniUsuario)
                .HasColumnType("character varying")
                .HasColumnName("dni_usuario");
            entity.Property(e => e.EmailUsuario)
                .HasColumnType("character varying")
                .HasColumnName("email_usuario");
            entity.Property(e => e.EstaBloqueadoUsuario).HasColumnName("estaBloqueado_usuario");
            entity.Property(e => e.FchAltaUsuario)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fch_alta_usuario");
            entity.Property(e => e.FchBajaUsuario)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fch_baja_usuario");
            entity.Property(e => e.FchFinBloqueo).HasColumnName("fch_fin_bloqueo");
            entity.Property(e => e.IdAcceso).HasColumnName("id_acceso");
            entity.Property(e => e.NombreUsuario)
                .HasColumnType("character varying")
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.TlfUsuario)
                .HasColumnType("character varying")
                .HasColumnName("tlf_usuario");

            entity.HasOne(d => d.IdAccesoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdAcceso)
                .HasConstraintName("idAcceso_idAcceso_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
