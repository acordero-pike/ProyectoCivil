using System;
using System.Collections.Generic;

namespace Bomberos.Models
{
    public partial class Turno
    {
        public Turno()
        {
            InEstructurals = new HashSet<InEstructural>();
            InForestals = new HashSet<InForestal>();
            InVehiculos = new HashSet<InVehiculo>();
            ServicioPrevencions = new HashSet<ServicioPrevencion>();
            ServicioVarios = new HashSet<ServicioVario>();
        }

        public string IdTurno { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Horario { get; set; }

        public virtual ICollection<InEstructural> InEstructurals { get; set; }
        public virtual ICollection<InForestal> InForestals { get; set; }
        public virtual ICollection<InVehiculo> InVehiculos { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencions { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarios { get; set; }
    }
}
