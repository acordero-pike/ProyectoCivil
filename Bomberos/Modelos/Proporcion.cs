using System;
using System.Collections.Generic;

namespace Bomberos.Modelos
{
    public partial class Proporcion
    {
        public Proporcion()
        {
            InEstructurals = new HashSet<InEstructural>();
            InForestals = new HashSet<InForestal>();
            InVehiculos = new HashSet<InVehiculo>();
        }

        public string IdProp { get; set; } = null!;
        public string? PTipoProp { get; set; }

        public virtual ICollection<InEstructural> InEstructurals { get; set; }
        public virtual ICollection<InForestal> InForestals { get; set; }
        public virtual ICollection<InVehiculo> InVehiculos { get; set; }
    }
}
