using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.Reservas
{
    public class InfoReserva
    {
        [Display(Name = "Número Reserva")]
        public string num_Res { get; set; }

        //[Display(Name = "Id Producto")]
        //public string id_Prod { get; set; }

        //[Display(Name = "Cantidad Reservada")]
        //public string cantidadReservada { get; set; }

        [Display(Name = "Dni Cliente")]
        public string dni_Cli { get; set; }

        [Display(Name = "Dni Peluquero")]
        public string dni_Pel { get; set; }
    }
}