using Aplicacion_BDPeluqueria.BaseDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.Reservas
{
    public class DetallesReserva
    {
        [Display(Name = "Número Reserva")]
        public string num_Res { get; set; }
        
        [Display(Name = "Dni Cliente")]
        public string dni_Cli { get; set; }

        [Display(Name = "Dni Peluquero")]
        public string dni_Pel { get; set; }

        [Display(Name = "Productos")]
        public string Lista { get; set; }

        [Display(Name = "Cantidad Reservada")]
        public string cantidad_Reservada { get; set; }
    }
}