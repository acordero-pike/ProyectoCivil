using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bomberos.Models
{
    public partial class InVehiculo
    {
        public string? IdIv { get; set; } = null!;
        [Display(Name = "Estación:")] 
        public string? IvEstacion { get; set; }
        [Display(Name = "Turno:")]
        public string? IvTurno { get; set; }
        [Display(Name = "Ubicacion del Siniestro:")]
        public string? IvUbiSiniestro { get; set; }
        [Display(Name = "Tipo de Vehiculo:")]
        public string? IvTipoVehiculo { get; set; }
        [Display(Name = "Placa:")]
        public string? IvPlaca { get; set; }
        [Display(Name = "Color:")]
        public string? IvColor { get; set; }
        [Display(Name = "Marca:")]
        public string? IvMarca { get; set; }
        [Display(Name = "Valor:")]
        public double? IvValor { get; set; }
        [Display(Name = "Perdida:")]
        public double? IvPerdida { get; set; }
        [Display(Name = "Proporción:")]
        public string? IdProp { get; set; }
        [Display(Name = "Tipo de Fuego:")]
        public string? IdCf { get; set; }
        [Display(Name = "Hora de Salida:")]
        [DataType(DataType.Time)]
        public TimeSpan? IvHoraSalida { get; set; }
        [Display(Name = "Hora de Servicio:")]
        [DataType(DataType.Time)]
        public TimeSpan? IvHoraServicio { get; set; }
        [Display(Name = "Hora de Entrada:")]
        [DataType(DataType.Time)]
        public TimeSpan? IvHoraEntrada { get; set; }
        [Display(Name = "Jefe de Servicio:")]
        public string? IvJefeServicio { get; set; }
        [Display(Name = "Telefonista de Turno:")]
        public string? IvTelefonistaTurno { get; set; }
        [Display(Name = "Bombero que Reporta:")]
        public string? IvBomberoReporta { get; set; }
        [Display(Name = "Piloto:")]
        public string? IvPiloto { get; set; }
        [Display(Name = "Unidad:")]
        public string? IvUnidad { get; set; }
        [Display(Name = "Otras Unidades Asistente de la Estación:")]
        public string? IvUniAsisEstacion { get; set; }
        [Display(Name = "Unidades Asistentes de Otras Estaciones:")]
        public string? IvUniAsisOtraEstacion { get; set; }
        [Display(Name = "Unidades Policiacas:")]
        public string? IvUniPoliciacas { get; set; }
        [Display(Name = "Unidades de Otras Instituciones Bomberiles:")]
        public string? IvUniOtrasInstiBomberiles { get; set; }
        [Display(Name = "Personal Asistente de la Estación:")]
        public string? IvPersonalAsisEstacion { get; set; }
        [Display(Name = " Personal Asistente de Otra Estaciones:")]
        public string? IvPersonalAsisOtraEstacion { get; set; }
        [Display(Name = "Observaciones:")]
        public string? IvObservacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha:")]
        public DateTime? IvFecha { get; set; }
        [Display(Name = "Kilometraje de Entrada:")]
        public double? IvKmEntrada { get; set; }
        [Display(Name = "Kilometraje de Salida:")]
        public double? IvKmSalida { get; set; }
        [Display(Name = "Kilometraje Recorrido:")]
        public double? IvKmRecorrido { get; set; }
        [Display(Name = "Firma de Bombero:")]
        public string? IvFirmaBombero { get; set; }
        [Display(Name = "No. Bombero:")]
        public long? IvNoBombero { get; set; }
        [Display(Name = "Vo. Bo. Jefe en Servicio:")]
        public string? IvVoBoJefeServicio { get; set; }
        [Display(Name = "Codigo:")]
        public string? Codigo { get; set; }
        [Display(Name = "Codigo:")]
        public virtual Codigo? CodigoNavigation { get; set; }
        [Display(Name = "Clase de fuego:")]
        public virtual ClaseFuego? IdCfNavigation { get; set; }
        [Display(Name = "Proporción:")]
        public virtual Proporcion? IdPropNavigation { get; set; }
        [Display(Name = "Bombero que Reporta:")]
        public virtual Usuario? IvBomberoReportaNavigation { get; set; }
        [Display(Name = "Estación:")]
        public virtual Estacion? IvEstacionNavigation { get; set; }
        [Display(Name = "Firma:")]
        public virtual Firma? IvFirmaBomberoNavigation { get; set; }
        [Display(Name = "Jefe de Servicio:")]
        public virtual Personal? IvJefeServicioNavigation { get; set; }
        [Display(Name = "Piloto:")]
        public virtual Personal? IvPilotoNavigation { get; set; }
        [Display(Name = "Telefonista de Turno:")]
        public virtual Personal? IvTelefonistaTurnoNavigation { get; set; }
        [Display(Name = "Turno:")]
        public virtual Turno? IvTurnoNavigation { get; set; }
        [Display(Name = "Vo. Bo. de Jefe en Servicio:")]
        public virtual Firma? IvVoBoJefeServicioNavigation { get; set; }
    }
}
