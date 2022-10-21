using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bomberos.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            InEstructurals = new HashSet<InEstructural>();
            InForestals = new HashSet<InForestal>();
            InVehiculos = new HashSet<InVehiculo>();
            ServicioPrevencions = new HashSet<ServicioPrevencion>();
            ServicioRescates = new HashSet<ServicioRescate>();
            ServicioVarios = new HashSet<ServicioVario>();
        }

        public string? IdUsuario { get; set; } = null!;
        [Required(ErrorMessage = "Porfavor Ingrese sus Nombres.")]
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "Porfavor Ingrese sus Apellidos.")]
        public string? Apellidos { get; set; }
        [Required(ErrorMessage = "Porfavor Ingrese un Correo Electronico.")]
        public string? Correo { get; set; }
        public bool Activo { get; set; }
        [Display(Name = "Usuario:")]
        [Required(ErrorMessage = "Porfavor Ingrese un Usuario.")]
       
        public string? UsUsuario { get; set; }
        [Display(Name = "Contraseña:")]
        [Required(ErrorMessage = "Porfavor Ingrese una Contraseña.")]
       
        public string? UsContraseña { get; set; }
        [Required]

        public virtual ICollection<InEstructural> InEstructurals { get; set; }
        public virtual ICollection<InForestal> InForestals { get; set; }
        public virtual ICollection<InVehiculo> InVehiculos { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencions { get; set; }
        public virtual ICollection<ServicioRescate> ServicioRescates { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarios { get; set; }
    }
}
