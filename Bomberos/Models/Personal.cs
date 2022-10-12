using System;
using System.Collections.Generic;

namespace Bomberos.Models
{
    public partial class Personal
    {
        public Personal()
        {
            InEstructuralIeJefeServicioNavigations = new HashSet<InEstructural>();
            InEstructuralIePilotoNavigations = new HashSet<InEstructural>();
            InEstructuralIeTelefonistaTurnoNavigations = new HashSet<InEstructural>();
            InForestalIfJefeServicioNavigations = new HashSet<InForestal>();
            InForestalIfPilotoNavigations = new HashSet<InForestal>();
            InForestalIfTelefonistaTurnoNavigations = new HashSet<InForestal>();
            InVehiculoIvJefeServicioNavigations = new HashSet<InVehiculo>();
            InVehiculoIvPilotoNavigations = new HashSet<InVehiculo>();
            InVehiculoIvTelefonistaTurnoNavigations = new HashSet<InVehiculo>();
            ServicioPrevencionSpOficialServicioNavigations = new HashSet<ServicioPrevencion>();
            ServicioPrevencionSpPilotoNavigations = new HashSet<ServicioPrevencion>();
            ServicioPrevencionSpTelefonistaNavigations = new HashSet<ServicioPrevencion>();
            ServicioRescateSrOficialMandoNavigations = new HashSet<ServicioRescate>();
            ServicioRescateSrTelefonistaTurnoEstacionNavigations = new HashSet<ServicioRescate>();
            ServicioVarioSvJefeServicioNavigations = new HashSet<ServicioVario>();
            ServicioVarioSvPersonalAsistenteNavigations = new HashSet<ServicioVario>();
            ServicioVarioSvPilotoNavigations = new HashSet<ServicioVario>();
            ServicioVarioSvServicioAutPorNavigations = new HashSet<ServicioVario>();
            ServicioVarioSvTelefonistaTurnoNavigations = new HashSet<ServicioVario>();
        }

        public string? IdPersonal { get; set; } = null!;
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Puesto { get; set; }

        public virtual ICollection<InEstructural> InEstructuralIeJefeServicioNavigations { get; set; }
        public virtual ICollection<InEstructural> InEstructuralIePilotoNavigations { get; set; }
        public virtual ICollection<InEstructural> InEstructuralIeTelefonistaTurnoNavigations { get; set; }
        public virtual ICollection<InForestal> InForestalIfJefeServicioNavigations { get; set; }
        public virtual ICollection<InForestal> InForestalIfPilotoNavigations { get; set; }
        public virtual ICollection<InForestal> InForestalIfTelefonistaTurnoNavigations { get; set; }
        public virtual ICollection<InVehiculo> InVehiculoIvJefeServicioNavigations { get; set; }
        public virtual ICollection<InVehiculo> InVehiculoIvPilotoNavigations { get; set; }
        public virtual ICollection<InVehiculo> InVehiculoIvTelefonistaTurnoNavigations { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencionSpOficialServicioNavigations { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencionSpPilotoNavigations { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencionSpTelefonistaNavigations { get; set; }
        public virtual ICollection<ServicioRescate> ServicioRescateSrOficialMandoNavigations { get; set; }
        public virtual ICollection<ServicioRescate> ServicioRescateSrTelefonistaTurnoEstacionNavigations { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarioSvJefeServicioNavigations { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarioSvPersonalAsistenteNavigations { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarioSvPilotoNavigations { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarioSvServicioAutPorNavigations { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarioSvTelefonistaTurnoNavigations { get; set; }
    }
}
