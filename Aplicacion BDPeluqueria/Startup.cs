using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Aplicacion_BDPeluqueria.Startup))]

namespace Aplicacion_BDPeluqueria
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
         
        }
    }
}
