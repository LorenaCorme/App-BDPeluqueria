using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.Peluqueros
{
    public class mPeluquero
    {
        [Required]
        [Display(Name = "Dni Peluquero")]
        [RegularExpression("^(([A-Z]\\d{8})|(\\d{8}[A-Z]))$", ErrorMessage = "Formato de Dni incorrecto")]
        public string dni_Pel { get; set; }

        [Required]
        [Display(Name = "Nombre Peluquero")]
        [MinLength(3), MaxLength(30)]
        public string nombre_Pel { get; set; }

        [Required]
        [Display(Name = "Apellidos Peluquero")]
        [MinLength(3), MaxLength(50)]
        public string apell_Pel { get; set; }

        [Required]
        [Display(Name = "Dirección Peluquero")]
        [MinLength(3), MaxLength(30)]
        public string dir_Pel { get; set; }
    }
}