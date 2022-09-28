using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bomberos.Models
{
    public partial class Usuario
    {
        
        public string? IdUsuario { get; set; }
        [Required]
        public string? Nombres { get; set; }
        [Required]
        public string? Apellidos { get; set; }
        [Required]
        public string? Correo { get; set; }
        public bool Activo { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "{0} Cree un usuario entre {2} y {1}.", MinimumLength = 6)]
        public string? UsUsuario { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "{0} Largo de contraseña entre {2} y {1}.", MinimumLength = 6)]
        public string? UsContraseña { get; set; }


        public virtual ICollection<ServicioVario> ServicioVarios { get; set; }
    }
}
