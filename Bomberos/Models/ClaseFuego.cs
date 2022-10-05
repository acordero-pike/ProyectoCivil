using System;
using System.Collections.Generic;

namespace Bomberos.Models
{
    public partial class ClaseFuego
    {
        public ClaseFuego()
        {
            InEstructurals = new HashSet<InEstructural>();
            InForestals = new HashSet<InForestal>();
            InVehiculos = new HashSet<InVehiculo>();
        }

        public string IdCf { get; set; } = null!;
        public string? CfClasefuego { get; set; }

        public virtual ICollection<InEstructural> InEstructurals { get; set; }
        public virtual ICollection<InForestal> InForestals { get; set; }
        public virtual ICollection<InVehiculo> InVehiculos { get; set; }
    }
}
