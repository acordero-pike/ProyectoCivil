using System;
using System.Collections.Generic;

namespace Bomberos.Modelos
{
    public partial class InEstructural
    {
        public string IdIe { get; set; } = null!;
        public string? IeEstacion { get; set; }
        public string? IeTurno { get; set; }
        public string? IeUbiSiniestro { get; set; }
        public string? IeInmueble { get; set; }
        public double? IeValor { get; set; }
        public double? IePerdida { get; set; }
        public string? IdProp { get; set; }
        public string? IeIdCf { get; set; }
        public TimeSpan? IeHoraSalida { get; set; }
        public TimeSpan? IeHoraServicio { get; set; }
        public TimeSpan? IeHoraEntrada { get; set; }
        public string? IeJefeServicio { get; set; }
        public string? IeTelefonistaTurno { get; set; }
        public string? IeBomberoReporta { get; set; }
        public string? IePiloto { get; set; }
        public string? IeUnidad { get; set; }
        public string? IeUniAsisEstacion { get; set; }
        public string? IeUniAsisOtraEstacion { get; set; }
        public string? IeUniPoliciacas { get; set; }
        public string? IeUniOtrasInstiBomberiles { get; set; }
        public string? IePersonalAsisEstacion { get; set; }
        public string? IePersonalAsisOtraEstacion { get; set; }
        public string? IeObservacion { get; set; }
        public DateTime? IeFecha { get; set; }
        public double? IeKmEntrada { get; set; }
        public double? IeKmSalida { get; set; }
        public double? IeKmRecorrido { get; set; }
        public string? IeFirmaBombero { get; set; }
        public long? IeNoBombero { get; set; }
        public string? IeVoBoJefeServicio { get; set; }
        public string? Codigo { get; set; }

        public virtual Codigo? CodigoNavigation { get; set; }
        public virtual Proporcion? IdPropNavigation { get; set; }
        public virtual Usuario? IeBomberoReportaNavigation { get; set; }
        public virtual Estacion? IeEstacionNavigation { get; set; }
        public virtual Firma? IeFirmaBomberoNavigation { get; set; }
        public virtual ClaseFuego? IeIdCfNavigation { get; set; }
        public virtual Personal? IeJefeServicioNavigation { get; set; }
        public virtual Personal? IePilotoNavigation { get; set; }
        public virtual Personal? IeTelefonistaTurnoNavigation { get; set; }
        public virtual Turno? IeTurnoNavigation { get; set; }
        public virtual Firma? IeVoBoJefeServicioNavigation { get; set; }
    }
}
