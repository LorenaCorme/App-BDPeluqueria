using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aplicacion_BDPeluqueria.Models.CasasComerciales
{
    public class InfoCasa
    {
        [Display(Name = "Nombre Casa Comercial")]
        public string nombre_Casa { get; set; }

        [Display(Name = "Localización")]
        public string local_Casa { get; set; }
        
    }
}