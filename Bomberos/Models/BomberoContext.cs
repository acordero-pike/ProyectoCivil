using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bomberos.Models
{
    public partial class BomberoContext : DbContext
    {
        public BomberoContext()
        {
        }

        public BomberoContext(DbContextOptions<BomberoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Bombero;user=sa;password=LDesarrollo#4;Trusted_Connection=false;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__4E3E04ADC4470727");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("id_usuario");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsContraseña)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("us_Contraseña");

                entity.Property(e => e.UsUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("us_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
