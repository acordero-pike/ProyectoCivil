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

        public virtual DbSet<ClaseFuego> ClaseFuegos { get; set; } = null!;
        public virtual DbSet<Codigo> Codigos { get; set; } = null!;
        public virtual DbSet<Compañium> Compañia { get; set; } = null!;
        public virtual DbSet<Estacion> Estacions { get; set; } = null!;
        public virtual DbSet<Firma> Firmas { get; set; } = null!;
        public virtual DbSet<InEstructural> InEstructurals { get; set; } = null!;
        public virtual DbSet<InForestal> InForestals { get; set; } = null!;
        public virtual DbSet<InVehiculo> InVehiculos { get; set; } = null!;
        public virtual DbSet<Personal> Personals { get; set; } = null!;
        public virtual DbSet<Proporcion> Proporcions { get; set; } = null!;
        public virtual DbSet<ServicioPrevencion> ServicioPrevencions { get; set; } = null!;
        public virtual DbSet<ServicioRescate> ServicioRescates { get; set; } = null!;
        public virtual DbSet<ServicioVario> ServicioVarios { get; set; } = null!;
        public virtual DbSet<Turno> Turnos { get; set; } = null!;
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
            modelBuilder.Entity<ClaseFuego>(entity =>
            {
                entity.HasKey(e => e.IdCf)
                    .HasName("PK__ClaseFue__00B7DEF50BF028D5");

                entity.ToTable("ClaseFuego");

                entity.Property(e => e.IdCf)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_cf")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CfClasefuego)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("cf_Clasefuego");
            });

            modelBuilder.Entity<Codigo>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PK__Codigo__65A475E70317E016");

                entity.ToTable("Codigo");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo1)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(130)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Compañium>(entity =>
            {
                entity.HasKey(e => e.IdCompañia)
                    .HasName("PK__Compañia__44D8D83FC72D48DF");

                entity.HasIndex(e => e.Nombre, "UQ__Compañia__75E3EFCF14B906D9")
                    .IsUnique();

                entity.Property(e => e.IdCompañia)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID_Compañia")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.HasKey(e => e.IdEstacion)
                    .HasName("PK__estacion__39C0B7D00B574CAA");

                entity.ToTable("estacion");

                entity.HasIndex(e => e.Nombre, "UQ__estacion__75E3EFCFCB4560FB")
                    .IsUnique();

                entity.Property(e => e.IdEstacion)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID_Estacion")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Firma>(entity =>
            {
                entity.HasKey(e => e.IdFirma)
                    .HasName("PK__Firma__765CD30F16CC16E7");

                entity.ToTable("Firma");

                entity.Property(e => e.IdFirma)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID_Firma")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Firma1)
                    .HasColumnType("image")
                    .HasColumnName("Firma");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InEstructural>(entity =>
            {
                entity.HasKey(e => e.IdIe)
                    .HasName("PK__InEstruc__00B7EE381BE41585");

                entity.ToTable("InEstructural");

                entity.Property(e => e.IdIe)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_ie")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.IdProp)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_prop");

                entity.Property(e => e.IeBomberoReporta)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("ie_BomberoReporta");

                entity.Property(e => e.IeEstacion)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ie_Estacion");

                entity.Property(e => e.IeFecha)
                    .HasColumnType("date")
                    .HasColumnName("ie_Fecha");

                entity.Property(e => e.IeFirmaBombero)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ie_FirmaBombero");

                entity.Property(e => e.IeHoraEntrada).HasColumnName("ie_HoraEntrada");

                entity.Property(e => e.IeHoraSalida).HasColumnName("ie_HoraSalida");

                entity.Property(e => e.IeHoraServicio).HasColumnName("ie_HoraServicio");

                entity.Property(e => e.IeIdCf)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ie_id_cf");

                entity.Property(e => e.IeInmueble)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ie_Inmueble");

                entity.Property(e => e.IeJefeServicio)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("ie_JefeServicio");

                entity.Property(e => e.IeKmEntrada).HasColumnName("ie_KmEntrada");

                entity.Property(e => e.IeKmRecorrido).HasColumnName("ie_KmRecorrido");

                entity.Property(e => e.IeKmSalida).HasColumnName("ie_KmSalida");

                entity.Property(e => e.IeNoBombero).HasColumnName("ie_NoBombero");

                entity.Property(e => e.IeObservacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ie_Observacion");

                entity.Property(e => e.IePerdida).HasColumnName("ie_Perdida");

                entity.Property(e => e.IePersonalAsisEstacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ie_PersonalAsisEstacion");

                entity.Property(e => e.IePersonalAsisOtraEstacion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ie_PersonalAsisOtraEstacion");

                entity.Property(e => e.IePiloto)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("ie_Piloto");

                entity.Property(e => e.IeTelefonistaTurno)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("ie_TelefonistaTurno");

                entity.Property(e => e.IeTurno)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ie_Turno");

                entity.Property(e => e.IeUbiSiniestro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ie_UbiSiniestro");

                entity.Property(e => e.IeUniAsisEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ie_UniAsisEstacion");

                entity.Property(e => e.IeUniAsisOtraEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ie_UniAsisOtraEstacion");

                entity.Property(e => e.IeUniOtrasInstiBomberiles)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ie_UniOtrasInstiBomberiles");

                entity.Property(e => e.IeUniPoliciacas)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ie_UniPoliciacas");

                entity.Property(e => e.IeUnidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ie_Unidad");

                entity.Property(e => e.IeValor).HasColumnName("ie_Valor");

                entity.Property(e => e.IeVoBoJefeServicio)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ie_VoBoJefeServicio");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.InEstructurals)
                    .HasForeignKey(d => d.Codigo)
                    .HasConstraintName("FK_InEstructural");

                entity.HasOne(d => d.IdPropNavigation)
                    .WithMany(p => p.InEstructurals)
                    .HasForeignKey(d => d.IdProp)
                    .HasConstraintName("FK_InEstructural.id_prop");

                entity.HasOne(d => d.IeBomberoReportaNavigation)
                    .WithMany(p => p.InEstructurals)
                    .HasForeignKey(d => d.IeBomberoReporta)
                    .HasConstraintName("FK_InEstructural.ie_BomberoReporta");

                entity.HasOne(d => d.IeEstacionNavigation)
                    .WithMany(p => p.InEstructurals)
                    .HasForeignKey(d => d.IeEstacion)
                    .HasConstraintName("FK_InEstructural.ie_Estacion");

                entity.HasOne(d => d.IeFirmaBomberoNavigation)
                    .WithMany(p => p.InEstructuralIeFirmaBomberoNavigations)
                    .HasForeignKey(d => d.IeFirmaBombero)
                    .HasConstraintName("FK_InEstructural.ie_FirmaBombero");

                entity.HasOne(d => d.IeIdCfNavigation)
                    .WithMany(p => p.InEstructurals)
                    .HasForeignKey(d => d.IeIdCf)
                    .HasConstraintName("FK_InEstructural.id_cf");

                entity.HasOne(d => d.IeJefeServicioNavigation)
                    .WithMany(p => p.InEstructuralIeJefeServicioNavigations)
                    .HasForeignKey(d => d.IeJefeServicio)
                    .HasConstraintName("FK_InEstructural.ie_JefeServicio");

                entity.HasOne(d => d.IePilotoNavigation)
                    .WithMany(p => p.InEstructuralIePilotoNavigations)
                    .HasForeignKey(d => d.IePiloto)
                    .HasConstraintName("FK_InEstructural.ie_Piloto");

                entity.HasOne(d => d.IeTelefonistaTurnoNavigation)
                    .WithMany(p => p.InEstructuralIeTelefonistaTurnoNavigations)
                    .HasForeignKey(d => d.IeTelefonistaTurno)
                    .HasConstraintName("FK_InEstructural.ie_TelefonistaTurno");

                entity.HasOne(d => d.IeTurnoNavigation)
                    .WithMany(p => p.InEstructurals)
                    .HasForeignKey(d => d.IeTurno)
                    .HasConstraintName("FK_InEstructural.ie_Turno");

                entity.HasOne(d => d.IeVoBoJefeServicioNavigation)
                    .WithMany(p => p.InEstructuralIeVoBoJefeServicioNavigations)
                    .HasForeignKey(d => d.IeVoBoJefeServicio)
                    .HasConstraintName("FK_InEstructural.ie_VoBoJefeServicio");
            });

            modelBuilder.Entity<InForestal>(entity =>
            {
                entity.HasKey(e => e.IdIf)
                    .HasName("PK__InForest__00B7EE3990FFB149");

                entity.ToTable("InForestal");

                entity.Property(e => e.IdIf)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_if")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.IdCf)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_cf");

                entity.Property(e => e.IdProp)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_prop");

                entity.Property(e => e.IfAreaAfectada)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("if_AreaAfectada");

                entity.Property(e => e.IfBomberoReporta)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("if_BomberoReporta");

                entity.Property(e => e.IfEstacion)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("if_Estacion");

                entity.Property(e => e.IfFecha)
                    .HasColumnType("date")
                    .HasColumnName("if_Fecha");

                entity.Property(e => e.IfFirmaBombero)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("if_FirmaBombero");

                entity.Property(e => e.IfHoraEntrada).HasColumnName("if_HoraEntrada");

                entity.Property(e => e.IfHoraSalida).HasColumnName("if_HoraSalida");

                entity.Property(e => e.IfHoraServicio).HasColumnName("if_HoraServicio");

                entity.Property(e => e.IfJefeServicio)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("if_JefeServicio");

                entity.Property(e => e.IfKmEntrada).HasColumnName("if_KmEntrada");

                entity.Property(e => e.IfKmRecorrido).HasColumnName("if_KmRecorrido");

                entity.Property(e => e.IfKmSalida).HasColumnName("if_KmSalida");

                entity.Property(e => e.IfNoBombero).HasColumnName("if_NoBombero");

                entity.Property(e => e.IfObservacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("if_Observacion");

                entity.Property(e => e.IfPersonalAsisEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("if_PersonalAsisEstacion");

                entity.Property(e => e.IfPersonalAsisOtraEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("if_PersonalAsisOtraEstacion");

                entity.Property(e => e.IfPiloto)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("if_Piloto");

                entity.Property(e => e.IfTelefonistaTurno)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("if_TelefonistaTurno");

                entity.Property(e => e.IfTipoTerreno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("if_TipoTerreno");

                entity.Property(e => e.IfTurno)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("if_Turno");

                entity.Property(e => e.IfUbiSiniestro)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("if_UbiSiniestro");

                entity.Property(e => e.IfUniAsisEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("if_UniAsisEstacion");

                entity.Property(e => e.IfUniAsisOtraEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("if_UniAsisOtraEstacion");

                entity.Property(e => e.IfUniOtrasInstiBomberiles)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("if_UniOtrasInstiBomberiles");

                entity.Property(e => e.IfUniPoliciacas)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("if_UniPoliciacas");

                entity.Property(e => e.IfUnidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("if_Unidad");

                entity.Property(e => e.IfVoBoJefeServicio)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("if_VoBoJefeServicio");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.InForestals)
                    .HasForeignKey(d => d.Codigo)
                    .HasConstraintName("FK_InForestal");

                entity.HasOne(d => d.IdCfNavigation)
                    .WithMany(p => p.InForestals)
                    .HasForeignKey(d => d.IdCf)
                    .HasConstraintName("FK_InForestal.id_cf");

                entity.HasOne(d => d.IdPropNavigation)
                    .WithMany(p => p.InForestals)
                    .HasForeignKey(d => d.IdProp)
                    .HasConstraintName("FK_InForestal.id_prop");

                entity.HasOne(d => d.IfBomberoReportaNavigation)
                    .WithMany(p => p.InForestals)
                    .HasForeignKey(d => d.IfBomberoReporta)
                    .HasConstraintName("FK_InForestal.if_BomberoReporta");

                entity.HasOne(d => d.IfEstacionNavigation)
                    .WithMany(p => p.InForestals)
                    .HasForeignKey(d => d.IfEstacion)
                    .HasConstraintName("FK_InForestal.if_Estacion");

                entity.HasOne(d => d.IfFirmaBomberoNavigation)
                    .WithMany(p => p.InForestalIfFirmaBomberoNavigations)
                    .HasForeignKey(d => d.IfFirmaBombero)
                    .HasConstraintName("FK_InForestal.if_FirmaBombero");

                entity.HasOne(d => d.IfJefeServicioNavigation)
                    .WithMany(p => p.InForestalIfJefeServicioNavigations)
                    .HasForeignKey(d => d.IfJefeServicio)
                    .HasConstraintName("FK_InForestal.if_JefeServicio");

                entity.HasOne(d => d.IfPilotoNavigation)
                    .WithMany(p => p.InForestalIfPilotoNavigations)
                    .HasForeignKey(d => d.IfPiloto)
                    .HasConstraintName("FK_InForestal.if_Piloto");

                entity.HasOne(d => d.IfTelefonistaTurnoNavigation)
                    .WithMany(p => p.InForestalIfTelefonistaTurnoNavigations)
                    .HasForeignKey(d => d.IfTelefonistaTurno)
                    .HasConstraintName("FK_InForestal.if_TelefonistaTurno");

                entity.HasOne(d => d.IfTurnoNavigation)
                    .WithMany(p => p.InForestals)
                    .HasForeignKey(d => d.IfTurno)
                    .HasConstraintName("FK_InForestal.if_Turno");

                entity.HasOne(d => d.IfVoBoJefeServicioNavigation)
                    .WithMany(p => p.InForestalIfVoBoJefeServicioNavigations)
                    .HasForeignKey(d => d.IfVoBoJefeServicio)
                    .HasConstraintName("FK_InForestal.if_VoBoJefeServicio");
            });

            modelBuilder.Entity<InVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdIv)
                    .HasName("PK__InVehicu__00B7EE29CC5E059C");

                entity.ToTable("InVehiculo");

                entity.Property(e => e.IdIv)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_iv")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.IdCf)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_cf");

                entity.Property(e => e.IdProp)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_prop");

                entity.Property(e => e.IvBomberoReporta)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("iv_BomberoReporta");

                entity.Property(e => e.IvColor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_Color");

                entity.Property(e => e.IvEstacion)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("iv_Estacion");

                entity.Property(e => e.IvFecha)
                    .HasColumnType("date")
                    .HasColumnName("iv_Fecha");

                entity.Property(e => e.IvFirmaBombero)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("iv_FirmaBombero");

                entity.Property(e => e.IvHoraEntrada).HasColumnName("iv_HoraEntrada");

                entity.Property(e => e.IvHoraSalida).HasColumnName("iv_HoraSalida");

                entity.Property(e => e.IvHoraServicio).HasColumnName("iv_HoraServicio");

                entity.Property(e => e.IvJefeServicio)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("iv_JefeServicio");

                entity.Property(e => e.IvKmEntrada).HasColumnName("iv_KmEntrada");

                entity.Property(e => e.IvKmRecorrido).HasColumnName("iv_KmRecorrido");

                entity.Property(e => e.IvKmSalida).HasColumnName("iv_KmSalida");

                entity.Property(e => e.IvMarca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_Marca");

                entity.Property(e => e.IvNoBombero).HasColumnName("iv_NoBombero");

                entity.Property(e => e.IvObservacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("iv_Observacion");

                entity.Property(e => e.IvPerdida).HasColumnName("iv_Perdida");

                entity.Property(e => e.IvPersonalAsisEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_PersonalAsisEstacion");

                entity.Property(e => e.IvPersonalAsisOtraEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_PersonalAsisOtraEstacion");

                entity.Property(e => e.IvPiloto)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("iv_Piloto");

                entity.Property(e => e.IvPlaca)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_Placa");

                entity.Property(e => e.IvTelefonistaTurno)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("iv_TelefonistaTurno");

                entity.Property(e => e.IvTipoVehiculo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_TipoVehiculo");

                entity.Property(e => e.IvTurno)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("iv_Turno");

                entity.Property(e => e.IvUbiSiniestro)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_UbiSiniestro");

                entity.Property(e => e.IvUniAsisEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_UniAsisEstacion");

                entity.Property(e => e.IvUniAsisOtraEstacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_UniAsisOtraEstacion");

                entity.Property(e => e.IvUniOtrasInstiBomberiles)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_UniOtrasInstiBomberiles");

                entity.Property(e => e.IvUniPoliciacas)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iv_UniPoliciacas");

                entity.Property(e => e.IvUnidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("iv_Unidad");

                entity.Property(e => e.IvValor).HasColumnName("iv_Valor");

                entity.Property(e => e.IvVoBoJefeServicio)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("iv_VoBoJefeServicio");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.InVehiculos)
                    .HasForeignKey(d => d.Codigo)
                    .HasConstraintName("FK_InVehiculo");

                entity.HasOne(d => d.IdCfNavigation)
                    .WithMany(p => p.InVehiculos)
                    .HasForeignKey(d => d.IdCf)
                    .HasConstraintName("FK_InVehiculo.id_cf");

                entity.HasOne(d => d.IdPropNavigation)
                    .WithMany(p => p.InVehiculos)
                    .HasForeignKey(d => d.IdProp)
                    .HasConstraintName("FK_InVehiculo.id_prop");

                entity.HasOne(d => d.IvBomberoReportaNavigation)
                    .WithMany(p => p.InVehiculos)
                    .HasForeignKey(d => d.IvBomberoReporta)
                    .HasConstraintName("FK_InVehiculo.iv_BomberoReporta");

                entity.HasOne(d => d.IvEstacionNavigation)
                    .WithMany(p => p.InVehiculos)
                    .HasForeignKey(d => d.IvEstacion)
                    .HasConstraintName("FK_InVehiculo.iv_Estacion");

                entity.HasOne(d => d.IvFirmaBomberoNavigation)
                    .WithMany(p => p.InVehiculoIvFirmaBomberoNavigations)
                    .HasForeignKey(d => d.IvFirmaBombero)
                    .HasConstraintName("FK_InVehiculo.iv_FirmaBombero");

                entity.HasOne(d => d.IvJefeServicioNavigation)
                    .WithMany(p => p.InVehiculoIvJefeServicioNavigations)
                    .HasForeignKey(d => d.IvJefeServicio)
                    .HasConstraintName("FK_InVehiculo.iv_JefeServicio");

                entity.HasOne(d => d.IvPilotoNavigation)
                    .WithMany(p => p.InVehiculoIvPilotoNavigations)
                    .HasForeignKey(d => d.IvPiloto)
                    .HasConstraintName("FK_InVehiculo.iv_Piloto");

                entity.HasOne(d => d.IvTelefonistaTurnoNavigation)
                    .WithMany(p => p.InVehiculoIvTelefonistaTurnoNavigations)
                    .HasForeignKey(d => d.IvTelefonistaTurno)
                    .HasConstraintName("FK_InVehiculo.iv_TelefonistaTurno");

                entity.HasOne(d => d.IvTurnoNavigation)
                    .WithMany(p => p.InVehiculos)
                    .HasForeignKey(d => d.IvTurno)
                    .HasConstraintName("FK_InVehiculo.iv_Turno");

                entity.HasOne(d => d.IvVoBoJefeServicioNavigation)
                    .WithMany(p => p.InVehiculoIvVoBoJefeServicioNavigations)
                    .HasForeignKey(d => d.IvVoBoJefeServicio)
                    .HasConstraintName("FK_InVehiculo.iv_VoBoJefeServicio");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPersonal)
                    .HasName("PK__Personal__11995ADD076F8FB8");

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
                    .HasMaxLength(100)
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

            modelBuilder.Entity<Proporcion>(entity =>
            {
                entity.HasKey(e => e.IdProp)
                    .HasName("PK__Proporci__0DA3484754FED7F0");

                entity.ToTable("Proporcion");

                entity.Property(e => e.IdProp)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_prop")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PTipoProp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("p_TipoProp");
            });

            modelBuilder.Entity<ServicioPrevencion>(entity =>
            {
                entity.HasKey(e => e.IdSp);

                entity.ToTable("ServicioPrevencion");

                entity.Property(e => e.IdSp)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_sp")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.SpBomberoReporta)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sp_BomberoReporta");

                entity.Property(e => e.SpCompañia)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("sp_Compañia");

                entity.Property(e => e.SpDireccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sp_Direccion");

                entity.Property(e => e.SpEstablecimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sp_Establecimiento");

                entity.Property(e => e.SpEstacion)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("sp_Estacion");

                entity.Property(e => e.SpFecha)
                    .HasColumnType("date")
                    .HasColumnName("sp_Fecha");

                entity.Property(e => e.SpFormaAviso)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sp_FormaAviso");

                entity.Property(e => e.SpGeneralesServPrestado)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("sp_GeneralesServPrestado");

                entity.Property(e => e.SpHoraEntrada).HasColumnName("sp_HoraEntrada");

                entity.Property(e => e.SpHoraSalida).HasColumnName("sp_HoraSalida");

                entity.Property(e => e.SpKmEntrada).HasColumnName("sp_KmEntrada");

                entity.Property(e => e.SpKmSalida).HasColumnName("sp_KmSalida");

                entity.Property(e => e.SpKmTotal).HasColumnName("sp_KmTotal");

                entity.Property(e => e.SpNombreRazonsocial)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sp_NombreRazonsocial");

                entity.Property(e => e.SpObservacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("sp_Observacion");

                entity.Property(e => e.SpOficialServicio)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sp_OficialServicio");

                entity.Property(e => e.SpPiloto)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sp_Piloto");

                entity.Property(e => e.SpTelefonista)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sp_Telefonista");

                entity.Property(e => e.SpTurno)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("sp_Turno");

                entity.Property(e => e.SpUnidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sp_Unidad");

                entity.Property(e => e.SpVoBoJefeServicio)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("sp_VoBoJefeServicio");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.ServicioPrevencions)
                    .HasForeignKey(d => d.Codigo)
                    .HasConstraintName("FK_ServicioPrevencion");

                entity.HasOne(d => d.SpBomberoReportaNavigation)
                    .WithMany(p => p.ServicioPrevencions)
                    .HasForeignKey(d => d.SpBomberoReporta)
                    .HasConstraintName("FK_ServicioPrevencion.sp_BomberoReporta");

                entity.HasOne(d => d.SpCompañiaNavigation)
                    .WithMany(p => p.ServicioPrevencions)
                    .HasForeignKey(d => d.SpCompañia)
                    .HasConstraintName("FK_ServicioPrevencion.sp_Compañia");

                entity.HasOne(d => d.SpEstacionNavigation)
                    .WithMany(p => p.ServicioPrevencions)
                    .HasForeignKey(d => d.SpEstacion)
                    .HasConstraintName("FK_ServicioPrevencion.sp_Estacion");

                entity.HasOne(d => d.SpOficialServicioNavigation)
                    .WithMany(p => p.ServicioPrevencionSpOficialServicioNavigations)
                    .HasForeignKey(d => d.SpOficialServicio)
                    .HasConstraintName("FK_ServicioPrevencion.sp_OficialServicio");

                entity.HasOne(d => d.SpPilotoNavigation)
                    .WithMany(p => p.ServicioPrevencionSpPilotoNavigations)
                    .HasForeignKey(d => d.SpPiloto)
                    .HasConstraintName("FK_ServicioPrevencion.sp_Piloto");

                entity.HasOne(d => d.SpTelefonistaNavigation)
                    .WithMany(p => p.ServicioPrevencionSpTelefonistaNavigations)
                    .HasForeignKey(d => d.SpTelefonista)
                    .HasConstraintName("FK_ServicioPrevencion.sp_Telefonista");

                entity.HasOne(d => d.SpTurnoNavigation)
                    .WithMany(p => p.ServicioPrevencions)
                    .HasForeignKey(d => d.SpTurno)
                    .HasConstraintName("FK_ServicioPrevencion.sp_Turno");

                entity.HasOne(d => d.SpVoBoJefeServicioNavigation)
                    .WithMany(p => p.ServicioPrevencions)
                    .HasForeignKey(d => d.SpVoBoJefeServicio)
                    .HasConstraintName("FK_ServicioPrevencion.sp_VoBoJefeServicio");
            });

            modelBuilder.Entity<ServicioRescate>(entity =>
            {
                entity.HasKey(e => e.IdSr)
                    .HasName("PK__Servicio__014858ED1D959F4A");

                entity.ToTable("ServicioRescate");

                entity.Property(e => e.IdSr)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_sr")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.SrApellidosPaciente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_ApellidosPaciente");

                entity.Property(e => e.SrAproxEstatura)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_AproxEstatura");

                entity.Property(e => e.SrBomberoReporta)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sr_BomberoReporta");

                entity.Property(e => e.SrCausa)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_Causa");

                entity.Property(e => e.SrColorPelo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_ColorPelo");

                entity.Property(e => e.SrColorZapatos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_ColorZapatos");

                entity.Property(e => e.SrDireccionPaciente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_DireccionPaciente");

                entity.Property(e => e.SrDireccionRescate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_DireccionRescate");

                entity.Property(e => e.SrEdad).HasColumnName("sr_Edad");

                entity.Property(e => e.SrEstacion)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("sr_Estacion");

                entity.Property(e => e.SrEstado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_Estado");

                entity.Property(e => e.SrFecha)
                    .HasColumnType("date")
                    .HasColumnName("sr_Fecha");

                entity.Property(e => e.SrFormaAviso)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_FormaAviso");

                entity.Property(e => e.SrHoraEntrada).HasColumnName("sr_HoraEntrada");

                entity.Property(e => e.SrHoraSalida).HasColumnName("sr_HoraSalida");

                entity.Property(e => e.SrKmEntrada).HasColumnName("sr_KmEntrada");

                entity.Property(e => e.SrKmSalida).HasColumnName("sr_KmSalida");

                entity.Property(e => e.SrKmTotal).HasColumnName("sr_KmTotal");

                entity.Property(e => e.SrLugarLocalizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_LugarLocalizacion");

                entity.Property(e => e.SrNoTelLlamaron).HasColumnName("sr_NoTelLlamaron");

                entity.Property(e => e.SrNombreJuez)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_NombreJuez");

                entity.Property(e => e.SrNombresPaciente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_NombresPaciente");

                entity.Property(e => e.SrObjetosPortaba)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_ObjetosPortaba");

                entity.Property(e => e.SrObservacion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("sr_Observacion");

                entity.Property(e => e.SrOficialMando)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sr_OficialMando");

                entity.Property(e => e.SrOtrasUniAsis)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_OtrasUniAsis");

                entity.Property(e => e.SrPatrullasCarSeg)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_Patrullas_CarSeg");

                entity.Property(e => e.SrPersonalAsistente)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_PersonalAsistente");

                entity.Property(e => e.SrPosicionEncontro)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_PosicionEncontro");

                entity.Property(e => e.SrRadioOpTurnoCentral)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_RadioOpTurnoCentral");

                entity.Property(e => e.SrRopaColor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_RopaColor");

                entity.Property(e => e.SrSexo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("sr_Sexo");

                entity.Property(e => e.SrSeñalesPartRescatado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_SeñalesPartRescatado");

                entity.Property(e => e.SrSiglasRadioLlamaron)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_SiglasRadioLlamaron");

                entity.Property(e => e.SrTelefonistaTurnoEstacion)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sr_TelefonistaTurnoEstacion");

                entity.Property(e => e.SrTraslado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_Traslado");

                entity.Property(e => e.SrUnidad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sr_Unidad");

                entity.Property(e => e.SrVoBoJefeServicio)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("sr_VoBoJefeServicio");

                entity.HasOne(d => d.SrBomberoReportaNavigation)
                    .WithMany(p => p.ServicioRescates)
                    .HasForeignKey(d => d.SrBomberoReporta)
                    .HasConstraintName("FK_ServicioRescate.sr_BomberoReporta");

                entity.HasOne(d => d.SrEstacionNavigation)
                    .WithMany(p => p.ServicioRescates)
                    .HasForeignKey(d => d.SrEstacion)
                    .HasConstraintName("FK_ServicioRescate.sr_Estacion");

                entity.HasOne(d => d.SrOficialMandoNavigation)
                    .WithMany(p => p.ServicioRescateSrOficialMandoNavigations)
                    .HasForeignKey(d => d.SrOficialMando)
                    .HasConstraintName("FK_ServicioRescate.sr_OficialMando");

                entity.HasOne(d => d.SrTelefonistaTurnoEstacionNavigation)
                    .WithMany(p => p.ServicioRescateSrTelefonistaTurnoEstacionNavigations)
                    .HasForeignKey(d => d.SrTelefonistaTurnoEstacion)
                    .HasConstraintName("FK_ServicioRescate.sr_TelefonistaTurnoEstacion");

                entity.HasOne(d => d.SrVoBoJefeServicioNavigation)
                    .WithMany(p => p.ServicioRescates)
                    .HasForeignKey(d => d.SrVoBoJefeServicio)
                    .HasConstraintName("FK_ServicioRescate.sr_VoBoJefeServicio");
            });

            modelBuilder.Entity<ServicioVario>(entity =>
            {
                entity.HasKey(e => e.IdSv)
                    .HasName("PK__Servicio__014858E91BDA1C48");

                entity.ToTable("ServicioVario");

                entity.Property(e => e.IdSv)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id_sv")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.SvBomberoReporta)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("sv_BomberoReporta");

                entity.Property(e => e.SvDireccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sv_Direccion");

                entity.Property(e => e.SvEstacion)
                    .HasMaxLength(36)
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
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("sv_Turno");

                entity.Property(e => e.SvUnidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sv_Unidad");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.ServicioVarios)
                    .HasForeignKey(d => d.Codigo)
                    .HasConstraintName("FK_ServicioVario_C");

                entity.HasOne(d => d.SvBomberoReportaNavigation)
                    .WithMany(p => p.ServicioVarios)
                    .HasForeignKey(d => d.SvBomberoReporta)
                    .HasConstraintName("FK_ServicioVario.sv_BomberoReporta");

                entity.HasOne(d => d.SvEstacionNavigation)
                    .WithMany(p => p.ServicioVarios)
                    .HasForeignKey(d => d.SvEstacion)
                    .HasConstraintName("FK_ServicioVario2");

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

                entity.HasOne(d => d.SvTurnoNavigation)
                    .WithMany(p => p.ServicioVarios)
                    .HasForeignKey(d => d.SvTurno)
                    .HasConstraintName("FK_ServicioVario");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno)
                    .HasName("PK__Turno__9FCE7EC7F6158D1C");

                entity.ToTable("Turno");

                entity.HasIndex(e => e.Nombre, "UQ__Turno__75E3EFCFD5803AC7")
                    .IsUnique();

                entity.Property(e => e.IdTurno)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("ID_Turno")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Horario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__4E3E04ADB345EF82");

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
