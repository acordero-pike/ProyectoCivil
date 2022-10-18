using System;
using System.Collections.Generic;

namespace Bomberos.Models
{
    public partial class ServicioVario
    {
        public string? IdSv { get; set; } = null!;
        public string? SvEstacion { get; set; }
        public string? SvTurno { get; set; }
        public DateTime? SvFecha { get; set; }
        public string? SvDireccion { get; set; }
        public string? SvServicio { get; set; }
        public TimeSpan? SvHoraSalida { get; set; }
        public TimeSpan? SvHoraEntrada { get; set; }
        public string? SvJefeServicio { get; set; }
        public string? SvTelefonistaTurno { get; set; }
        public string? SvBomberoReporta { get; set; }
        public string? SvUnidad { get; set; }
        public string? SvPiloto { get; set; }
        public string? SvServicioAutPor { get; set; }
        public string? SvPersonalAsistente { get; set; }
        public string? SvObservacion { get; set; }
        public double? SvKmEntrada { get; set; }
        public double? SvKmSalida { get; set; }
        public double? SvKmRecorrido { get; set; }
        public string? SvFirmaBombero { get; set; }
        public long? SvNoBombero { get; set; }
        public string? Codigo { get; set; }

        public virtual Codigo? CodigoNavigation { get; set; }
        public virtual Usuario? SvBomberoReportaNavigation { get; set; }
        public virtual Firma? SvFirmaBomberoNavigation { get; set; }
        public virtual Personal? SvJefeServicioNavigation { get; set; }
        public virtual Personal? SvPersonalAsistenteNavigation { get; set; }
        public virtual Personal? SvPilotoNavigation { get; set; }
        public virtual Personal? SvServicioAutPorNavigation { get; set; }
        public virtual Personal? SvTelefonistaTurnoNavigation { get; set; }
    }
}
