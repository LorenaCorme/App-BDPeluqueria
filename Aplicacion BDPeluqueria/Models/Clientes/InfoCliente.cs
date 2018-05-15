using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.Clientes
{
    public class InfoCliente
    {
        [Display(Name = "Dni Cliente")]
        public string dni_Cli { get; set; }

        [Display(Name = "Nombre Cliente")]
        public string nombre_Cli { get; set; }

        [Display(Name = "Apellido Cliente")]
        public string apell_Cli { get; set; }

        [Display(Name = "Dirección Cliente")]
        public string dir_Cli { get; set; }

        [Display(Name = "Dni Peluquero")]
        public string dni_Pel { get; set; }
    }
}