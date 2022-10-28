using System;
using System.Collections.Generic;

namespace Bomberos.Modelos
{
    public partial class Estacion
    {
        public Estacion()
        {
            InEstructurals = new HashSet<InEstructural>();
            InForestals = new HashSet<InForestal>();
            InVehiculos = new HashSet<InVehiculo>();
            ServicioPrevencions = new HashSet<ServicioPrevencion>();
            ServicioRescates = new HashSet<ServicioRescate>();
            ServicioVarios = new HashSet<ServicioVario>();
        }

        public string IdEstacion { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<InEstructural> InEstructurals { get; set; }
        public virtual ICollection<InForestal> InForestals { get; set; }
        public virtual ICollection<InVehiculo> InVehiculos { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencions { get; set; }
        public virtual ICollection<ServicioRescate> ServicioRescates { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarios { get; set; }
    }
}
