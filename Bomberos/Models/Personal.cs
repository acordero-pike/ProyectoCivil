using System;
using System.Collections.Generic;

namespace Bomberos.Models
{
    public partial class Personal
    {
        public Personal()
        {
            ServicioVarioSvJefeServicioNavigations = new HashSet<ServicioVario>();
            ServicioVarioSvPersonalAsistenteNavigations = new HashSet<ServicioVario>();
            ServicioVarioSvPilotoNavigations = new HashSet<ServicioVario>();
            ServicioVarioSvServicioAutPorNavigations = new HashSet<ServicioVario>();
            ServicioVarioSvTelefonistaTurnoNavigations = new HashSet<ServicioVario>();
        }

        public string? IdPersonal { get; set; } 
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Puesto { get; set; }

        public virtual ICollection<ServicioVario> ServicioVarioSvJefeServicioNavigations { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarioSvPersonalAsistenteNavigations { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarioSvPilotoNavigations { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarioSvServicioAutPorNavigations { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarioSvTelefonistaTurnoNavigations { get; set; }
    }
}
