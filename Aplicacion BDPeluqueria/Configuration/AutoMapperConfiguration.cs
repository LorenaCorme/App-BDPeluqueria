using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aplicacion_BDPeluqueria.BaseDatos;

using Aplicacion_BDPeluqueria.Models.Clientes;
using Aplicacion_BDPeluqueria.Models.CuentaUsuarios;
using Aplicacion_BDPeluqueria.Models.Peluqueros;
using Aplicacion_BDPeluqueria.Models.Productos;
using Aplicacion_BDPeluqueria.Models.Reservas;
using AutoMapper;

namespace Aplicacion_BDPeluqueria.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            ConfigReservas();
            ConfigClientes();
            ConfigPeluqueros();
            ConfigProductos();
            ConfigUsuarios();
        }

        private  void ConfigReservas()
        {
            CreateMap<Reserva, InfoReserva>()
                // .ForMember(x => x.id_Prod, opt => opt.MapFrom(x => ))
                .ForMember(x => x.dni_Cli, opt => opt.MapFrom(x => x.dni_Cli))
                .ForMember(x => x.dni_Pel, opt => opt.MapFrom(x => x.dni_Pel))
                .ForMember(x => x.num_Res, opt => opt.MapFrom(x => x.num_Res));
        }

        private void ConfigClientes()
        {
            CreateMap<Cliente, InfoCliente>()
                // .ForMember(x => x.id_Prod, opt => opt.MapFrom(x => ))
                .ForMember(x => x.dni_Cli, opt => opt.MapFrom(x => x.dni_Cli))
                .ForMember(x => x.nombre_Cli, opt => opt.MapFrom(x => x.nombre_Cli))
                .ForMember(x => x.apell_Cli, opt => opt.MapFrom(x => x.apell_Cli))
                .ForMember(x => x.dir_Cli, opt => opt.MapFrom(x => x.dir_Cli))
                .ForMember(x => x.dni_Pel, opt => opt.MapFrom(x => x.dni_Pel));
            
    }
        private void ConfigPeluqueros()
        {
            CreateMap<Peluquero, InfoPeluquero>()
                // .ForMember(x => x.id_Prod, opt => opt.MapFrom(x => ))
                .ForMember(x => x.dni_Pel, opt => opt.MapFrom(x => x.dni_Pel))
                .ForMember(x => x.nombre_Pel, opt => opt.MapFrom(x => x.nombre_Pel))
                .ForMember(x => x.apell_Pel, opt => opt.MapFrom(x => x.apell_Pel))
                .ForMember(x => x.dir_Pel, opt => opt.MapFrom(x => x.dir_Pel));

        }

        private void ConfigProductos()
        {
            CreateMap<Producto, InfoProducto>()
                // .ForMember(x => x.id_Prod, opt => opt.MapFrom(x => ))
                .ForMember(x => x.id_Prod, opt => opt.MapFrom(x => x.id_Prod))
                .ForMember(x => x.nombre_Prod, opt => opt.MapFrom(x => x.nombre_Prod))
                .ForMember(x => x.cantidad, opt => opt.MapFrom(x => x.cantidad))
                .ForMember(x => x.nombre_Casa, opt => opt.MapFrom(x => x.nombre_Casa));
    }

        private void ConfigUsuarios()
        {
            CreateMap<Usuario, mUsuarios>()
                // .ForMember(x => x.id_Prod, opt => opt.MapFrom(x => ))
                .ForMember(x => x.usuario, opt => opt.MapFrom(x => x.usuario1))
                .ForMember(x => x.email, opt => opt.MapFrom(x => x.correo))
                .ForMember(x => x.contraseña, opt => opt.MapFrom(x => x.contraseña));
               // .ForMember(x => x.recuerdame, opt => opt.MapFrom(x => x.));
        }
    }
}