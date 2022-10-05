using System;
using System.Collections.Generic;

namespace Bomberos.Models
{
    public partial class InForestal
    {
        public string IdIf { get; set; } = null!;
        public string? IfEstacion { get; set; }
        public string? IfTurno { get; set; }
        public string? IfUbiSiniestro { get; set; }
        public string? IfAreaAfectada { get; set; }
        public string? IfTipoTerreno { get; set; }
        public string? IdProp { get; set; }
        public string? IdCf { get; set; }
        public TimeSpan? IfHoraSalida { get; set; }
        public TimeSpan? IfHoraServicio { get; set; }
        public TimeSpan? IfHoraEntrada { get; set; }
        public string? IfJefeServicio { get; set; }
        public string? IfTelefonistaTurno { get; set; }
        public string? IfBomberoReporta { get; set; }
        public string? IfPiloto { get; set; }
        public string? IfUnidad { get; set; }
        public string? IfUniAsisEstacion { get; set; }
        public string? IfUniAsisOtraEstacion { get; set; }
        public string? IfUniPoliciacas { get; set; }
        public string? IfUniOtrasInstiBomberiles { get; set; }
        public string? IfPersonalAsisEstacion { get; set; }
        public string? IfPersonalAsisOtraEstacion { get; set; }
        public string? IfObservacion { get; set; }
        public DateTime? IfFecha { get; set; }
        public double? IfKmEntrada { get; set; }
        public double? IfKmSalida { get; set; }
        public double? IfKmRecorrido { get; set; }
        public string? IfFirmaBombero { get; set; }
        public long? IfNoBombero { get; set; }
        public string? IfVoBoJefeServicio { get; set; }

        public virtual ClaseFuego? IdCfNavigation { get; set; }
        public virtual Proporcion? IdPropNavigation { get; set; }
        public virtual Usuario? IfBomberoReportaNavigation { get; set; }
        public virtual Estacion? IfEstacionNavigation { get; set; }
        public virtual Firma? IfFirmaBomberoNavigation { get; set; }
        public virtual Personal? IfJefeServicioNavigation { get; set; }
        public virtual Personal? IfPilotoNavigation { get; set; }
        public virtual Personal? IfTelefonistaTurnoNavigation { get; set; }
        public virtual Turno? IfTurnoNavigation { get; set; }
        public virtual Firma? IfVoBoJefeServicioNavigation { get; set; }
    }
}
