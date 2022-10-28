using System;
using System.Collections.Generic;

namespace Bomberos.Modelos
{
    public partial class InVehiculo
    {
        public string IdIv { get; set; } = null!;
        public string? IvEstacion { get; set; }
        public string? IvTurno { get; set; }
        public string? IvUbiSiniestro { get; set; }
        public string? IvTipoVehiculo { get; set; }
        public string? IvPlaca { get; set; }
        public string? IvColor { get; set; }
        public string? IvMarca { get; set; }
        public double? IvValor { get; set; }
        public double? IvPerdida { get; set; }
        public string? IdProp { get; set; }
        public string? IdCf { get; set; }
        public TimeSpan? IvHoraSalida { get; set; }
        public TimeSpan? IvHoraServicio { get; set; }
        public TimeSpan? IvHoraEntrada { get; set; }
        public string? IvJefeServicio { get; set; }
        public string? IvTelefonistaTurno { get; set; }
        public string? IvBomberoReporta { get; set; }
        public string? IvPiloto { get; set; }
        public string? IvUnidad { get; set; }
        public string? IvUniAsisEstacion { get; set; }
        public string? IvUniAsisOtraEstacion { get; set; }
        public string? IvUniPoliciacas { get; set; }
        public string? IvUniOtrasInstiBomberiles { get; set; }
        public string? IvPersonalAsisEstacion { get; set; }
        public string? IvPersonalAsisOtraEstacion { get; set; }
        public string? IvObservacion { get; set; }
        public DateTime? IvFecha { get; set; }
        public double? IvKmEntrada { get; set; }
        public double? IvKmSalida { get; set; }
        public double? IvKmRecorrido { get; set; }
        public string? IvFirmaBombero { get; set; }
        public long? IvNoBombero { get; set; }
        public string? IvVoBoJefeServicio { get; set; }
        public string? Codigo { get; set; }

        public virtual Codigo? CodigoNavigation { get; set; }
        public virtual ClaseFuego? IdCfNavigation { get; set; }
        public virtual Proporcion? IdPropNavigation { get; set; }
        public virtual Usuario? IvBomberoReportaNavigation { get; set; }
        public virtual Estacion? IvEstacionNavigation { get; set; }
        public virtual Firma? IvFirmaBomberoNavigation { get; set; }
        public virtual Personal? IvJefeServicioNavigation { get; set; }
        public virtual Personal? IvPilotoNavigation { get; set; }
        public virtual Personal? IvTelefonistaTurnoNavigation { get; set; }
        public virtual Turno? IvTurnoNavigation { get; set; }
        public virtual Firma? IvVoBoJefeServicioNavigation { get; set; }
    }
}
