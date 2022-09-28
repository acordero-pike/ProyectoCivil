using System;
using System.Collections.Generic;

namespace Bomberos.Models
{
    public partial class Firma
    {
        public Firma()
        {
            ServicioVarios = new HashSet<ServicioVario>();
        }

        public string? IdFirma { get; set; }
        public string? Tipo { get; set; }
        public string? Nombre { get; set; }
        public byte[]? Firma1 { get; set; }

        public virtual ICollection<ServicioVario> ServicioVarios { get; set; }
    }
}
