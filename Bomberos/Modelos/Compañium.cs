using System;
using System.Collections.Generic;

namespace Bomberos.Modelos
{
    public partial class Compañium
    {
        public Compañium()
        {
            ServicioPrevencions = new HashSet<ServicioPrevencion>();
        }

        public string IdCompañia { get; set; } = null!;
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<ServicioPrevencion> ServicioPrevencions { get; set; }
    }
}
