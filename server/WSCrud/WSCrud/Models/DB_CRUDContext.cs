using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WSCrud.Models
{
    public partial class DB_CRUDContext : DbContext
    {
        public DB_CRUDContext()
        {
        }

        public DB_CRUDContext(DbContextOptions<DB_CRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbEntidad> TbEntidads { get; set; }
        public virtual DbSet<TbTipoContribuyente> TbTipoContribuyentes { get; set; }
        public virtual DbSet<TbTipoDocumento> TbTipoDocumentos { get; set; }
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DB_CRUD;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TbEntidad>(entity =>
            {
                entity.HasKey(e => e.IdEntidad)
                    .HasName("PK__tb_entid__939AFD25B6E494D2");

                entity.ToTable("tb_entidad");

                entity.Property(e => e.IdEntidad).HasColumnName("id_entidad");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estato)
                    .HasColumnName("estato")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdTipoContribuyente).HasColumnName("id_tipo_contribuyente");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.NombreComercial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre_comercial");

                entity.Property(e => e.NroDocumento)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nro_documento");

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("razon_social");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdTipoContribuyenteNavigation)
                    .WithMany(p => p.TbEntidads)
                    .HasForeignKey(d => d.IdTipoContribuyente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tb_entida__id_ti__1920BF5C");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.TbEntidads)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tb_entida__id_ti__182C9B23");
            });

            modelBuilder.Entity<TbTipoContribuyente>(entity =>
            {
                entity.HasKey(e => e.IdTipoContribuyente)
                    .HasName("PK__tb_tipo___A5BD38380547B3A9");

                entity.ToTable("tb_tipo_contribuyente");

                entity.Property(e => e.IdTipoContribuyente).HasColumnName("id_tipo_contribuyente");

                entity.Property(e => e.Estato)
                    .HasColumnName("estato")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TbTipoDocumento>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK__tb_tipo___9F38507CB3C218DA");

                entity.ToTable("tb_tipo_documento");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estato)
                    .HasColumnName("estato")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__tb_usuar__4E3E04AD050DB42A");

                entity.ToTable("tb_usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
