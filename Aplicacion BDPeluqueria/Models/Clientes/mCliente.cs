using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.Clientes
{
    public class mCliente
    {
        [Required]
        [Display(Name = "Dni Cliente")]
        [RegularExpression("^(([A-Z]\\d{8})|(\\d{8}[A-Z]))$", ErrorMessage = "Formato de Dni incorrecto")]
        public string dni_Cli { get; set; }

        [Required]
        [Display(Name = "Nombre Cliente")]
        [MinLength(3), MaxLength(30)]
        public string nombre_Cli { get; set; }

        [Required]
        [Display(Name = "Apellidos Cliente")]
        [MinLength(3), MaxLength(50)]
        public string apell_Cli { get; set; }

        [Required]
        [Display(Name = "Dirección Cliente")]
        [MinLength(3), MaxLength(30)]
        public string dir_Cli { get; set; }

        [Required]
        [Display(Name = "Dni Peluquero")]
        [RegularExpression("^(([A-Z]\\d{8})|(\\d{8}[A-Z]))$", ErrorMessage = "Formato de Dni incorrecto")]
        public string dni_Pel { get; set; }
    }
}