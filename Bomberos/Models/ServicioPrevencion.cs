using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bomberos.Models
{
    public partial class ServicioPrevencion
    {
        public string? IdSp { get; set; } = null!;
        [Display(Name = "Dirección:")]
        public string? SpDireccion { get; set; }
        [Display(Name = "Razon Social:")]
        public string? SpNombreRazonsocial { get; set; }
        [Display(Name = "Servicios Generales Prestados:")]
        public string? SpGeneralesServPrestado { get; set; }
        [Display(Name = "Establecimiento:")]
        public string? SpEstablecimiento { get; set; }
        [Display(Name = "Hora de Salida")]
        [DataType(DataType.Time)]
        public TimeSpan? SpHoraSalida { get; set; }
        [Display(Name = "Hora de Entrada")]
        [DataType(DataType.Time)]
        public TimeSpan? SpHoraEntrada { get; set; }
        [Display(Name = "Unidad:")]
        public string? SpUnidad { get; set; }
        [Display(Name = "Piloto:")]
        public string? SpPiloto { get; set; }
        [Display(Name = "Forma de Aviso:")]
        public string? SpFormaAviso { get; set; }
        [Display(Name = "Telefonista:")]
        public string? SpTelefonista { get; set; }
        [Display(Name = "Oficial de Servicio:")]
        public string? SpOficialServicio { get; set; }
        [Display(Name = "Estación:")]
        public string? SpEstacion { get; set; }
        [Display(Name = "Compañia:")]
        public string? SpCompañia { get; set; }
        [Display(Name = "Turno:")]
        public string? SpTurno { get; set; }
        [Display(Name = "Observación:")]
        public string? SpObservacion { get; set; }
        [Display(Name = "Km de Salida:")]
        public double? SpKmSalida { get; set; }
        [Display(Name = "Km de Entrada:")]
        public double? SpKmEntrada { get; set; }
        [Display(Name = "Km recorridos en total:")]
        public double? SpKmTotal { get; set; }
        [Display(Name = "Bombero que reporta:")]
        public string? SpBomberoReporta { get; set; }
        [Display(Name = "Fecha:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SpFecha { get; set; }
        [Display(Name = "Vo.Bo. Jefe de Servicio:")]
        public string? SpVoBoJefeServicio { get; set; }
        [Display(Name = "Codigo:")]
        public string? Codigo { get; set; }
        [Display(Name = "Codigo de Navegacion:")]
        public virtual Codigo? CodigoNavigation { get; set; }
        [Display(Name = "Bombero que Reporta:")]
        public virtual Usuario? SpBomberoReportaNavigation { get; set; }
        [Display(Name = "Compañia:")]
        public virtual Compañium? SpCompañiaNavigation { get; set; }
        [Display(Name = "Estación:")]
        public virtual Estacion? SpEstacionNavigation { get; set; }
        [Display(Name = "Oficial de Servicio:")]
        public virtual Personal? SpOficialServicioNavigation { get; set; }
        [Display(Name = "Piloto:")]
        public virtual Personal? SpPilotoNavigation { get; set; }
        [Display(Name = "Telefonista:")]
        public virtual Personal? SpTelefonistaNavigation { get; set; }
        [Display(Name = "Turno:")]
        public virtual Turno? SpTurnoNavigation { get; set; }
        [Display(Name = "Vo.Bo. Jefe de Servicio:")]
        public virtual Firma? SpVoBoJefeServicioNavigation { get; set; }
    }
}
