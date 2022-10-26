using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bomberos.Models
{
    public partial class Codigo
    {
        public Codigo()
        {
            InEstructurals = new HashSet<InEstructural>();
            InForestals = new HashSet<InForestal>();
            InVehiculos = new HashSet<InVehiculo>();
            ServicioPrevencions = new HashSet<ServicioPrevencion>();
            ServicioRescates = new HashSet<ServicioRescate>();
            ServicioVarios = new HashSet<ServicioVario>();
        }

        public string? Uuid { get; set; } = null!;
        [Display(Name = "No. de Codigo:")]
        [Required(ErrorMessage = "Porfavor Ingrese un Numero de Codigo.")]
       
        public string? Codigo1 { get; set; }
        [Display(Name = "Descripción:")]
        [Required(ErrorMessage = "Porfavor Ingrese el Nombre del Codigo.")]
        public string? Descripcion { get; set; }

        public virtual ICollection<InEstructural> InEstructurals { get; set; }
        public virtual ICollection<InForestal> InForestals { get; set; }
        public virtual ICollection<InVehiculo> InVehiculos { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencions { get; set; }
        public virtual ICollection<ServicioRescate> ServicioRescates { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarios { get; set; }
    }
}
