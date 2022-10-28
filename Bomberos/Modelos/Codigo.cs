using System;
using System.Collections.Generic;

namespace Bomberos.Modelos
{
    public partial class Codigo
    {
        public Codigo()
        {
            InEstructurals = new HashSet<InEstructural>();
            InForestals = new HashSet<InForestal>();
            InVehiculos = new HashSet<InVehiculo>();
            ServicioPrevencions = new HashSet<ServicioPrevencion>();
            ServicioVarios = new HashSet<ServicioVario>();
        }

        public string Uuid { get; set; } = null!;
        public string? Codigo1 { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<InEstructural> InEstructurals { get; set; }
        public virtual ICollection<InForestal> InForestals { get; set; }
        public virtual ICollection<InVehiculo> InVehiculos { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencions { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarios { get; set; }
    }
}
