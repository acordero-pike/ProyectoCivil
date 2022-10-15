using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bomberos.Models
{
    public partial class InEstructural
    {
        public string? IdIe { get; set; } = null!;
        [Display(Name = "Estación:")]
        public string? IeEstacion { get; set; }
        [Display(Name = "Turno:")]
        public string? IeTurno { get; set; }
        [Display(Name = "Ubicación del Siniestro:")]
        public string? IeUbiSiniestro { get; set; }
        [Display(Name = "Inmueble:")]
        public string? IeInmueble { get; set; }
        [Display(Name = "Valor:")]
        public double? IeValor { get; set; }
        [Display(Name = "Pérdida:")]
        public double? IePerdida { get; set; }
        public string? IdProp { get; set; }
        public string? IeIdCf { get; set; }
        [Display(Name = "Hora de Salida")]
        [DataType(DataType.Time)]
        public TimeSpan? IeHoraSalida { get; set; }
        [Display(Name = "Hora de Servicio Efectivo:")]
        [DataType(DataType.Time)]
        public TimeSpan? IeHoraServicio { get; set; }
        [Display(Name = "Hora de Entrada:")]
        [DataType(DataType.Time)]
        public TimeSpan? IeHoraEntrada { get; set; }
        public string? IeJefeServicio { get; set; }
        public string? IeTelefonistaTurno { get; set; }
        public string? IeBomberoReporta { get; set; }
        public string? IePiloto { get; set; }
        [Display(Name = "Unidad:")]
        public string? IeUnidad { get; set; }
        [Display(Name = "Otras Unidades Asistente de la Estación:")]
        public string? IeUniAsisEstacion { get; set; }
        [Display(Name = "Unidades Asistentes de Otras Estaciones:")]
        public string? IeUniAsisOtraEstacion { get; set; }
        [Display(Name = "Unidades Policiacas:")]
        public string? IeUniPoliciacas { get; set; }
        [Display(Name = "Unidades de Otras Instituciones Bomberiles:")]
        public string? IeUniOtrasInstiBomberiles { get; set; }
        [Display(Name = "Personal Asistente de la Estación:")]
        public string? IePersonalAsisEstacion { get; set; }
        [Display(Name = " Personal Asistente de Otra Estaciones:")]
        public string? IePersonalAsisOtraEstacion { get; set; }
        [Display(Name = "Observaciones:")]
        public string? IeObservacion { get; set; }
        [Display(Name = "Fecha:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IeFecha { get; set; }
        [Display(Name = "Kilometraje de Entrada:")]
        public double? IeKmEntrada { get; set; }
        [Display(Name = "Kilometraje de Salida:")]
        public double? IeKmSalida { get; set; }
        [Display(Name = "Kilometros Recorridos:")]
        public double? IeKmRecorrido { get; set; }
        [Display(Name = "Firma de Bombero:")]
        public string? IeFirmaBombero { get; set; }
        [Display(Name = "No. Bombero:")]
        public long? IeNoBombero { get; set; }
        [Display(Name = "Vo. Bo. Jefe en Servicio:")]
        public string? IeVoBoJefeServicio { get; set; }
        [Display(Name = "Codigo:")]
        public string? Codigo { get; set; }
        [Display(Name = "Codigo:")]
        public virtual Codigo? CodigoNavigation { get; set; }
        [Display(Name = "Proporción:")]
        public virtual Proporcion? IdPropNavigation { get; set; }
        [Display(Name = "Bombero que Reporta:")]
        public virtual Usuario? IeBomberoReportaNavigation { get; set; }
        [Display(Name = "Estación:")]
        public virtual Estacion? IeEstacionNavigation { get; set; }
        [Display(Name = "Firma de Bombero:")]
        public virtual Firma? IeFirmaBomberoNavigation { get; set; }
        [Display(Name = "Clase de Fuego:")]
        public virtual ClaseFuego? IeIdCfNavigation { get; set; }
        [Display(Name = "Jefe de Servicio:")]
        public virtual Personal? IeJefeServicioNavigation { get; set; }
        [Display(Name = "Piloto:")]
        public virtual Personal? IePilotoNavigation { get; set; }
        [Display(Name = "Telefonista de Turno:")]
        public virtual Personal? IeTelefonistaTurnoNavigation { get; set; }
        [Display(Name = "Turno:")]
        public virtual Turno? IeTurnoNavigation { get; set; }
        [Display(Name = "Vo. Bo. Jefe en Servicio:")]
        public virtual Firma? IeVoBoJefeServicioNavigation { get; set; }
    }
}
