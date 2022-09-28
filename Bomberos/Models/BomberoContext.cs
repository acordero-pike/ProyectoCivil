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

        public virtual DbSet<Firma> Firmas { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<ServicioVario> ServicioVarios { get; set; } = null!;
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
            modelBuilder.Entity<Firma>(entity =>
            {
                entity.HasKey(e => e.IdFirma)
                    .HasName("PK__Firma__765CD30FD1908526");

                entity.ToTable("Firma");

                entity.Property(e => e.IdFirma)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID_Firma")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Firma1)
                    .HasMaxLength(1)
                    .HasColumnName("Firma")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPersonal)
                    .HasName("PK__Personal__11995ADD24231123");

                entity.ToTable("Personal");

                entity.Property(e => e.IdPersonal)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("ID_Personal")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServicioVario>(entity =>
            {
                entity.HasKey(e => e.IdSv)
                    .HasName("PK__Servicio__014858E99B8D4914");

                entity.ToTable("ServicioVario");

                entity.Property(e => e.IdSv)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_sv")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SvBomberoReporta)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sv_BomberoReporta");

                entity.Property(e => e.SvDireccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sv_Direccion");

                entity.Property(e => e.SvEstacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sv_Estacion");

                entity.Property(e => e.SvFecha)
                    .HasColumnType("date")
                    .HasColumnName("sv_Fecha");

                entity.Property(e => e.SvFirmaBombero)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("sv_FirmaBombero");

                entity.Property(e => e.SvHoraEntrada).HasColumnName("sv_horaEntrada");

                entity.Property(e => e.SvHoraSalida).HasColumnName("sv_HoraSalida");

                entity.Property(e => e.SvJefeServicio)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sv_JefeServicio");

                entity.Property(e => e.SvKmEntrada).HasColumnName("sv_KmEntrada");

                entity.Property(e => e.SvKmRecorrido).HasColumnName("sv_KmRecorrido");

                entity.Property(e => e.SvKmSalida).HasColumnName("sv_KmSalida");

                entity.Property(e => e.SvNoBombero).HasColumnName("sv_NoBombero");

                entity.Property(e => e.SvObservacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("sv_Observacion");

                entity.Property(e => e.SvPersonalAsistente)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sv_PersonalAsistente");

                entity.Property(e => e.SvPiloto)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sv_Piloto");

                entity.Property(e => e.SvServicio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sv_Servicio");

                entity.Property(e => e.SvServicioAutPor)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sv_ServicioAutPor");

                entity.Property(e => e.SvTelefonistaTurno)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sv_TelefonistaTurno");

                entity.Property(e => e.SvTurno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sv_Turno");

                entity.Property(e => e.SvUnidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sv_Unidad");

                entity.HasOne(d => d.SvBomberoReportaNavigation)
                    .WithMany(p => p.ServicioVarios)
                    .HasForeignKey(d => d.SvBomberoReporta)
                    .HasConstraintName("FK_ServicioVario.sv_BomberoReporta");

                entity.HasOne(d => d.SvFirmaBomberoNavigation)
                    .WithMany(p => p.ServicioVarios)
                    .HasForeignKey(d => d.SvFirmaBombero)
                    .HasConstraintName("FK_ServicioVario.sv_FirmaBombero");

                entity.HasOne(d => d.SvJefeServicioNavigation)
                    .WithMany(p => p.ServicioVarioSvJefeServicioNavigations)
                    .HasForeignKey(d => d.SvJefeServicio)
                    .HasConstraintName("FK_ServicioVario.sv_JefeServicio");

                entity.HasOne(d => d.SvPersonalAsistenteNavigation)
                    .WithMany(p => p.ServicioVarioSvPersonalAsistenteNavigations)
                    .HasForeignKey(d => d.SvPersonalAsistente)
                    .HasConstraintName("FK_ServicioVario.sv_PersonalAsistente");

                entity.HasOne(d => d.SvPilotoNavigation)
                    .WithMany(p => p.ServicioVarioSvPilotoNavigations)
                    .HasForeignKey(d => d.SvPiloto)
                    .HasConstraintName("FK_ServicioVario.sv_Piloto");

                entity.HasOne(d => d.SvServicioAutPorNavigation)
                    .WithMany(p => p.ServicioVarioSvServicioAutPorNavigations)
                    .HasForeignKey(d => d.SvServicioAutPor)
                    .HasConstraintName("FK_ServicioVario.sv_ServicioAutPor");

                entity.HasOne(d => d.SvTelefonistaTurnoNavigation)
                    .WithMany(p => p.ServicioVarioSvTelefonistaTurnoNavigations)
                    .HasForeignKey(d => d.SvTelefonistaTurno)
                    .HasConstraintName("FK_ServicioVario.sv_TelefonistaTurno");
            });

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
