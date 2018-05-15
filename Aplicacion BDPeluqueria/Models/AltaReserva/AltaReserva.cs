using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.AltaReserva
{
    public class AltaReserva
    {
        [Required]
        [Display(Name = "Número Reserva")]
        [StringLength(4)]
        public string num_Res { get; set; }

        [Required]
        [Display(Name = "Id Producto")]
        [StringLength(4)]
        public string id_Prod { get; set; }

        [Required]
        [Display(Name = "Cantidad Reservada")]
        [StringLength(4)]
        public string cantidadReservada { get; set; }

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