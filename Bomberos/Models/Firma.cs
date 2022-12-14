using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bomberos.Models
{
    public partial class Firma
    {
        public Firma()
        {
            InEstructuralIeFirmaBomberoNavigations = new HashSet<InEstructural>();
            InEstructuralIeVoBoJefeServicioNavigations = new HashSet<InEstructural>();
            InForestalIfFirmaBomberoNavigations = new HashSet<InForestal>();
            InForestalIfVoBoJefeServicioNavigations = new HashSet<InForestal>();
            InVehiculoIvFirmaBomberoNavigations = new HashSet<InVehiculo>();
            InVehiculoIvVoBoJefeServicioNavigations = new HashSet<InVehiculo>();
            ServicioPrevencions = new HashSet<ServicioPrevencion>();
            ServicioRescates = new HashSet<ServicioRescate>();
            ServicioVarios = new HashSet<ServicioVario>();
        }

        public string? IdFirma { get; set; } = null!;
        [Display(Name = "Cargo de Firmante:")]
        [Required(ErrorMessage = "Porfavor Ingrese un Cargo.")]
        public string? Tipo { get; set; }
        [Display(Name = "Nombre de Firmante:")]
        [Required(ErrorMessage = "Porfavor Ingrese su Nombre.")]
        public string? Nombre { get; set; }
        [Display(Name = "Firma:")]       
        public byte[]? Firma1 { get; set; }

        public virtual ICollection<InEstructural> InEstructuralIeFirmaBomberoNavigations { get; set; }
        public virtual ICollection<InEstructural> InEstructuralIeVoBoJefeServicioNavigations { get; set; }
        public virtual ICollection<InForestal> InForestalIfFirmaBomberoNavigations { get; set; }
        public virtual ICollection<InForestal> InForestalIfVoBoJefeServicioNavigations { get; set; }
        public virtual ICollection<InVehiculo> InVehiculoIvFirmaBomberoNavigations { get; set; }
        public virtual ICollection<InVehiculo> InVehiculoIvVoBoJefeServicioNavigations { get; set; }
        public virtual ICollection<ServicioPrevencion> ServicioPrevencions { get; set; }
        public virtual ICollection<ServicioRescate> ServicioRescates { get; set; }
        public virtual ICollection<ServicioVario> ServicioVarios { get; set; }
    }
}
