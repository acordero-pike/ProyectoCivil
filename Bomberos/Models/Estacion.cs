using Bomberos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bomberos.Models
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

        public string? IdEstacion { get; set; } = null!;
        [Display(Name = "Nombre de Estacion:")]
        [Required(ErrorMessage = "Porfavor Ingrese el Nombre de la Estacion.")]
        public string? Nombre { get; set; }
        [Display(Name = "Ubicación:")]
        [Required(ErrorMessage = "Porfavor Ingrese la Ubicacion de la Estacion.")]
        public string? Descripcion { get; set; }


        public virtual ICollection<InEstructural> InEstructurals { get; set; }
        public virtual ICollection<InForestal> InForestals { get; set; }
        public virtual ICollection<InVehiculo> InVehiculos { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencions { get; set; }
        public virtual ICollection<ServicioRescate> ServicioRescates { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarios { get; set; }
    }
}
