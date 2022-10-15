using System;
using System.Collections.Generic;

namespace Bomberos.Models
{
    public partial class ServicioPrevencion
    {
        public string? IdSp { get; set; } = null!;
        public string? SpDireccion { get; set; }
        public string? SpNombreRazonsocial { get; set; }
        public string? SpGeneralesServPrestado { get; set; }
        public string? SpEstablecimiento { get; set; }
        public TimeSpan? SpHoraSalida { get; set; }
        public TimeSpan? SpHoraEntrada { get; set; }
        public string? SpUnidad { get; set; }
        public string? SpPiloto { get; set; }
        public string? SpFormaAviso { get; set; }
        public string? SpTelefonista { get; set; }
        public string? SpOficialServicio { get; set; }
        public string? SpEstacion { get; set; }
        public string? SpCompañia { get; set; }
        public string? SpTurno { get; set; }
        public string? SpObservacion { get; set; }
        public double? SpKmSalida { get; set; }
        public double? SpKmEntrada { get; set; }
        public double? SpKmTotal { get; set; }
        public string? SpBomberoReporta { get; set; }
        public DateTime? SpFecha { get; set; }
        public string? SpVoBoJefeServicio { get; set; }
        public string? Codigo { get; set; }

        public virtual Codigo? CodigoNavigation { get; set; }
        public virtual Usuario? SpBomberoReportaNavigation { get; set; }
        public virtual Compañium? SpCompañiaNavigation { get; set; }
        public virtual Estacion? SpEstacionNavigation { get; set; }
        public virtual Personal? SpOficialServicioNavigation { get; set; }
        public virtual Personal? SpPilotoNavigation { get; set; }
        public virtual Personal? SpTelefonistaNavigation { get; set; }
        public virtual Turno? SpTurnoNavigation { get; set; }
        public virtual Firma? SpVoBoJefeServicioNavigation { get; set; }
    }
}
