using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bomberos.Models
{
    public partial class InForestal
    {
        
        public string? IdIf { get; set; } = null!;
        [Display(Name ="Estación:")]
        public string? IfEstacion { get; set; }
        [Display(Name = "Turno:")]
        public string? IfTurno { get; set; }
        [Display(Name = "Ubicación del Siniestro:")]
        public string? IfUbiSiniestro { get; set; }
        [Display(Name = "Área Afectada:")]
        public string? IfAreaAfectada { get; set; }
        [Display(Name = "Tipo de Terreno:")]
        public string? IfTipoTerreno { get; set; }
        [Display(Name = "Proporción:")]
        public string? IdProp { get; set; }
        [Display(Name = "Clase de Fuego:")]
        public string? IdCf { get; set; }
        [Display(Name = "Horario de Salida:")]
        [DataType(DataType.Time)]
        public TimeSpan? IfHoraSalida { get; set; }
        [Display(Name = "Horario de Servicio:")]
        [DataType(DataType.Time)]
        public TimeSpan? IfHoraServicio { get; set; }
        [Display(Name = "Horario de Entrada:")]
        [DataType(DataType.Time)]
        public TimeSpan? IfHoraEntrada { get; set; }
        [Display(Name = "Jefe de Servicio:")]
        public string? IfJefeServicio { get; set; }
        [Display(Name = "Telefonista de Turno:")]
        public string? IfTelefonistaTurno { get; set; }
        [Display(Name = "Bombero que Reporta:")]
        public string? IfBomberoReporta { get; set; }
        [Display(Name = "Piloto:")]
        public string? IfPiloto { get; set; }
        [Display(Name = "Unidad:")]
        public string? IfUnidad { get; set; }
        [Display(Name = "Otras Unidades Asistente de la Estación:")]
        public string? IfUniAsisEstacion { get; set; }
        [Display(Name = "Unidades Asistentes de Otras Estaciones:")] 
        public string? IfUniAsisOtraEstacion { get; set; }
        [Display(Name = "Unidades Policiacas:")] 
        public string? IfUniPoliciacas { get; set; }
        [Display(Name = "Unidades de Otras Instituciones Bomberiles:")] 
        public string? IfUniOtrasInstiBomberiles { get; set; }
        [Display(Name = "Personal Asistente de la Estación:")]
        public string? IfPersonalAsisEstacion { get; set; }
        [Display(Name = " Personal Asistente de Otra Estaciones:")]
        public string? IfPersonalAsisOtraEstacion { get; set; }
        [Display(Name = "Observaciones:")]
        public string? IfObservacion { get; set; }
        [Display(Name = "Fecha:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? IfFecha { get; set; }
        [Display(Name = "Kilometraje de Entrada:")] 
        public double? IfKmEntrada { get; set; }
        [Display(Name = "Kilometraje de Salida:")]
        public double? IfKmSalida { get; set; }
        [Display(Name = "Kilometraje de Recorrido:")]
        public double? IfKmRecorrido { get; set; }
        [Display(Name = "Firma de Bombero:")] 
        public string? IfFirmaBombero { get; set; }
        [Display(Name = "No. Bombero:")]
        public long? IfNoBombero { get; set; }
        [Display(Name = "Vo. Bo. Jefe en Servicio:")]
        public string? IfVoBoJefeServicio { get; set; }
        [Display(Name = "Codigo:")]
        public string? Codigo { get; set; }
        [Display(Name = "Codigo:")]
        public virtual Codigo? CodigoNavigation { get; set; }
        [Display(Name = "Clase de Fuego:")]
        public virtual ClaseFuego? IdCfNavigation { get; set; }
        [Display(Name = "Proporción:")]
        public virtual Proporcion? IdPropNavigation { get; set; }
        [Display(Name = "Bombero que Reporta:")] 
        public virtual Usuario? IfBomberoReportaNavigation { get; set; }
        [Display(Name = "Estación:")]
        public virtual Estacion? IfEstacionNavigation { get; set; }
        [Display(Name = "Firma de Bombero:")]
        public virtual Firma? IfFirmaBomberoNavigation { get; set; }
        [Display(Name = "Jefe de Servicio:")]
        public virtual Personal? IfJefeServicioNavigation { get; set; }
        [Display(Name = "Piloto:")]
        public virtual Personal? IfPilotoNavigation { get; set; }
        [Display(Name = "Telefonista de Turno:")]
        public virtual Personal? IfTelefonistaTurnoNavigation { get; set; }
        [Display(Name = "Turno:")]
        public virtual Turno? IfTurnoNavigation { get; set; }
        [Display(Name = "Vo. Bo Jefe en Servicio:")]
        public virtual Firma? IfVoBoJefeServicioNavigation { get; set; }
    }
}
