using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.Peluqueros
{
    public class InfoPeluquero
    {
        [Display(Name = "Dni Peluquero")]
        public string dni_Pel { get; set; }

        [Display(Name = "Nombre Peluquero")]
        public string nombre_Pel { get; set; }

        [Display(Name = "Apellido Peluquero")]
        public string apell_Pel { get; set; }

        [Display(Name = "Dirección Peluquero")]
        public string dir_Pel { get; set; }
        
    }
}