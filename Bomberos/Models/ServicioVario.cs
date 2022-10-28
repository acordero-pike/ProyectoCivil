using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bomberos.Models
{
    public partial class ServicioVario
    {
        public string? IdSv { get; set; } = null!;
        [Display(Name = "Estación:")]
        public string? SvEstacion { get; set; }
        [Display(Name = "Turno:")]
        public string? SvTurno { get; set; }
        [Display(Name = "Fecha:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SvFecha { get; set; }
        [Display(Name = "Dirección:")]
        public string? SvDireccion { get; set; }
        [Display(Name = "Servicio:")]
        public string? SvServicio { get; set; }
        [Display(Name = "Hora de Salida")]
        [DataType(DataType.Time)]
        public TimeSpan? SvHoraSalida { get; set; }
        [Display(Name = "Hora de Entrada")]
        [DataType(DataType.Time)]
        public TimeSpan? SvHoraEntrada { get; set; }
        [Display(Name = "Jefe de Servicio:")]
        public string? SvJefeServicio { get; set; }
        [Display(Name = "Telefonista de Turno:")]
        public string? SvTelefonistaTurno { get; set; }
        [Display(Name = "Bombero que reporta:")]
        public string? SvBomberoReporta { get; set; }
        [Display(Name = "Unidad:")]
        public string? SvUnidad { get; set; }
        [Display(Name = "Piloto:")]
        public string? SvPiloto { get; set; }
        [Display(Name = "Servicio:")]
        public string? SvServicioAutPor { get; set; }
        [Display(Name = "Asistente:")]
        public string? SvPersonalAsistente { get; set; }
        [Display(Name = "Observacion:")]
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
        public virtual Estacion? SvEstacionNavigation { get; set; }

        public virtual Turno? SvTurnoNavigation { get; set; }
    }
}
