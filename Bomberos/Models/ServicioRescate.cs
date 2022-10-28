using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bomberos.Models
{
    public partial class ServicioRescate
    {
        public string? IdSr { get; set; } = null!;
        [Display(Name = "Estación:")]
        public string? SrEstacion { get; set; }
        [Display(Name = "Dirección de Rescate:")]
        public string? SrDireccionRescate { get; set; }
        [Display(Name = "Lugar:")]
        public string? SrLugarLocalizacion { get; set; }
        [Display(Name = "Estado:")]
        public string? SrEstado { get; set; }
        [Display(Name = "Nombre de Paciente:")]
        public string? SrNombresPaciente { get; set; }
        [Display(Name = "Apellidos de Paciente:")]
        public string? SrApellidosPaciente { get; set; }
        [Display(Name = "Causa:")]
        public string? SrCausa { get; set; }
        [Display(Name = "Dirección de Paciente:")]
        public string? SrDireccionPaciente { get; set; }
        [Display(Name = "Edad:")]
        public int? SrEdad { get; set; }
        [Display(Name = "Genero:")]
        public string? SrSexo { get; set; }
        [Display(Name = "Color de Ropa:")]
        public string? SrRopaColor { get; set; }
        [Display(Name = "Color de Zapatos:")]
        public string? SrColorZapatos { get; set; }
        [Display(Name = "Objetos que portaba:")]
        public string? SrObjetosPortaba { get; set; }
        [Display(Name = "Color de pelo:")]
        public string? SrColorPelo { get; set; }
        [Display(Name = "Estatura Aproximada:")]
        public string? SrAproxEstatura { get; set; }
        [Display(Name = "Posición en que se encontro:")]
        public string? SrPosicionEncontro { get; set; }
        [Display(Name = "Traslado:")]
        public string? SrTraslado { get; set; }
        [Display(Name = "Unidad:")]
        public string? SrUnidad { get; set; }
        [Display(Name = "Otras Unidades de Asistencia:")]
        public string? SrOtrasUniAsis { get; set; }
        [Display(Name = "Nombre de Juez:")]
        public string? SrNombreJuez { get; set; }
        [Display(Name = "Señales:")]
        public string? SrSeñalesPartRescatado { get; set; }
        [Display(Name = "Forma de Aviso:")]
        public string? SrFormaAviso { get; set; }
        [Display(Name = "No. de telefono al que llamaron:")]
        public int? SrNoTelLlamaron { get; set; }
        [Display(Name = "Radio a la que llamaron:")]
        public string? SrSiglasRadioLlamaron { get; set; }
        [Display(Name = "Radio de turno:")]
        public string? SrRadioOpTurnoCentral { get; set; }
        [Display(Name = "Telefonista de tuno:")]
        public string? SrTelefonistaTurnoEstacion { get; set; }
        [Display(Name = "Oficial al mando:")]
        public string? SrOficialMando { get; set; }
        [Display(Name = "Hora de Salida")]
        [DataType(DataType.Time)]
        public TimeSpan? SrHoraSalida { get; set; }
        [Display(Name = "Hora de Entrada")]
        [DataType(DataType.Time)]
        public TimeSpan? SrHoraEntrada { get; set; }
        [Display(Name = "Patrullas a cargo:")]
        public string? SrPatrullasCarSeg { get; set; }
        [Display(Name = "Personal asistente:")]
        public string? SrPersonalAsistente { get; set; }
        [Display(Name = "Observación:")]
        public string? SrObservacion { get; set; }
        public double? SrKmSalida { get; set; }
        public double? SrKmEntrada { get; set; }
        public double? SrKmTotal { get; set; }
        [Display(Name = "Bombero que reporta:")]
        public string? SrBomberoReporta { get; set; }
        [Display(Name = "Fecha:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SrFecha { get; set; }
        public string? SrVoBoJefeServicio { get; set; }
        public string? Codigo { get; set; }

        public virtual Codigo? CodigoNavigation { get; set; }
        public virtual Usuario? SrBomberoReportaNavigation { get; set; }
        public virtual Estacion? SrEstacionNavigation { get; set; }
        public virtual Personal? SrOficialMandoNavigation { get; set; }
        public virtual Personal? SrTelefonistaTurnoEstacionNavigation { get; set; }
        public virtual Firma? SrVoBoJefeServicioNavigation { get; set; }
    }
}
