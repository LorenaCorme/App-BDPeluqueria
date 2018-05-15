using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.Reservas
{
    public class mReserva
    {
        [Required]
        [Range(0, short.MaxValue, ErrorMessage = "Debe ingresar un valor numérico.")]
        [Display(Name = "Número Reserva")]
        [MinLength(4)][MaxLength(4)]
        public string num_Res { get; set; }

        [Required]
        [Display(Name = "Dni Cliente")]
        [StringLength(9)]
        public string dni_Cli { get; set; }

        [Required]
        [Display(Name = "Dni Peluquero")]
        [StringLength(9)]
        public string dni_Pel { get; set; }

    }
}