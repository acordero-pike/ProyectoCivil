using System;
using System.Collections.Generic;

namespace Bomberos.Models
{
    public partial class ServicioRescate
    {
        public string? IdSr { get; set; } = null!;
        public string? SrEstacion { get; set; }
        public string? SrDireccionRescate { get; set; }
        public string? SrLugarLocalizacion { get; set; }
        public string? SrEstado { get; set; }
        public string? SrNombresPaciente { get; set; }
        public string? SrApellidosPaciente { get; set; }
        public string? SrCausa { get; set; }
        public string? SrDireccionPaciente { get; set; }
        public int? SrEdad { get; set; }
        public string? SrSexo { get; set; }
        public string? SrRopaColor { get; set; }
        public string? SrColorZapatos { get; set; }
        public string? SrObjetosPortaba { get; set; }
        public string? SrColorPelo { get; set; }
        public string? SrAproxEstatura { get; set; }
        public string? SrPosicionEncontro { get; set; }
        public string? SrTraslado { get; set; }
        public string? SrUnidad { get; set; }
        public string? SrOtrasUniAsis { get; set; }
        public string? SrNombreJuez { get; set; }
        public string? SrSeñalesPartRescatado { get; set; }
        public string? SrFormaAviso { get; set; }
        public int? SrNoTelLlamaron { get; set; }
        public string? SrSiglasRadioLlamaron { get; set; }
        public string? SrRadioOpTurnoCentral { get; set; }
        public string? SrTelefonistaTurnoEstacion { get; set; }
        public string? SrOficialMando { get; set; }
        public TimeSpan? SrHoraSalida { get; set; }
        public TimeSpan? SrHoraEntrada { get; set; }
        public string? SrPatrullasCarSeg { get; set; }
        public string? SrPersonalAsistente { get; set; }
        public string? SrObservacion { get; set; }
        public double? SrKmSalida { get; set; }
        public double? SrKmEntrada { get; set; }
        public double? SrKmTotal { get; set; }
        public string? SrBomberoReporta { get; set; }
        public DateTime? SrFecha { get; set; }
        public string? SrVoBoJefeServicio { get; set; }

        public virtual Usuario? SrBomberoReportaNavigation { get; set; }
        public virtual Estacion? SrEstacionNavigation { get; set; }
        public virtual Personal? SrOficialMandoNavigation { get; set; }
        public virtual Personal? SrTelefonistaTurnoEstacionNavigation { get; set; }
        public virtual Firma? SrVoBoJefeServicioNavigation { get; set; }
    }
}
