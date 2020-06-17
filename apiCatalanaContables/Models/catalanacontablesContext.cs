using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apiCatalanaContables.Models
{
    public partial class catalanacontablesContext : DbContext
    {
        

        public catalanacontablesContext(DbContextOptions<catalanacontablesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<PermisosUsuarios> PermisosUsuarios { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          /*  if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=catalanacontables;Integrated Security=True");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("fk_areas");
            });

            modelBuilder.Entity<Cargos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cargo)
                    .HasColumnName("cargo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("fk_cargos");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.Departamento)
                    .HasColumnName("departamento")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("fk_depa");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abreviatura)
                    .HasColumnName("abreviatura")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .HasColumnName("empresa")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Permiso)
                    .IsRequired()
                    .HasColumnName("permiso")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PermisosUsuarios>(entity =>
            {
                entity.ToTable("Permisos_Usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PermisoId).HasColumnName("permiso_id");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.Permiso)
                    .WithMany(p => p.PermisosUsuarios)
                    .HasForeignKey(d => d.PermisoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_permisoP");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.PermisosUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarioP");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("text");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasColumnName("rol")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("apellidos")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.CargoId).HasColumnName("cargo_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartamentoId).HasColumnName("departamento_id");

                entity.Property(e => e.Dui)
                    .HasColumnName("dui")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");

                entity.Property(e => e.Idempleado).HasColumnName("idempleado");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("nombres")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("fk_areaU");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CargoId)
                    .HasConstraintName("fk_cargoU");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("fk_depaU");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("fk_empresaU");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("fk_rolU");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
