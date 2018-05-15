using Aplicacion_BDPeluqueria.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Aplicacion_BDPeluqueria.Controllers
{
    public class UsuariosController : Controller
    {
        private BDPeluqueriaEntities1 db = new BDPeluqueriaEntities1();


        // GET: User
        public ActionResult Index()
        {
            return View();
        }
  

        /// <summary>
        /// Realizar el llamado de la vista que contiene la GUI de Autenticación de la aplicación
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Acceso()
        {
            return View();
        }

        /// <summary>
        /// Verificar los datos suministrados por el usuario al realizar la petición Post de envió de información
        /// mediante la GUI de Autenticación de la aplicación.
        /// </summary>
        /// <param name=”user”></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Acceso(Models.CuentaUsuarios.mUsuarios usuario)
        {
            if (ModelState.IsValid) //Verificar que el modelo de datos sea válido en cuanto a la definición de las propiedades
            {
                if (Isvalid(usuario.email, usuario.contraseña))//Verificar que el email y clave exista utilizando el método privado
                {

                    FormsAuthentication.SetAuthCookie(usuario.email, false); //crea variable de usuario con el correo del usuario
                    return RedirectToAction("Index", "Home"); //dirigir al controlador home vista Index una vez se a autenticado en el sistema
                }
                else
                {
                    ModelState.AddModelError("", "Login data in incorrect"); //adicionar mensaje de error al model
                }
            }
            return View(usuario);
        }

        /// <summary>
        /// Realizar el llamado de la vista que contiene la GUI, para registrarse en el sistema
        /// </summary>
        /// <returns></returns>
        public ActionResult Registrar()
        {
            ViewBag.usuario = new SelectList(db.Usuarios, "usuario", "usuario");
            return View();
        }

        /// <summary>
        /// Verificar los datos suministrados por el usuario al realizar la petición Post de envió de información
        /// mediante la GUI para crear un nuevo usuario en el sistema
        /// </summary>
        /// <param name=”user”></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Registrar(Models.CuentaUsuarios.mUsuarios user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BDPeluqueriaEntities1()) //crear objeto con referencia a la base de datos para crear el nuevo usuario
                {
                    var sysUser = db.Usuarios.Create();
                    sysUser.usuario1 = user.usuario;
                    sysUser.correo = user.email;
                    sysUser.contraseña = user.contraseña;
                  //  sysUser. = user.contraseña;
                   // sysUser.id = Guid.NewGuid();

                    db.Usuarios.Add(sysUser);
                    db.SaveChanges();
                    return RedirectToAction("Registrar", "Usuarios");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect"); //adicionar mensaje de error al model
            }

            return View();
        }

        /// <summary>
        /// Cerrar sesión del usuario autenticado
        /// </summary>
        /// <returns></returns>
        public ActionResult Salir()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        /// <summary>
        /// Metodo para validar el email y password del usuario, realiza la consulta a la base de datos
        /// </summary>
        /// <param name=”Email”>Email ingresado</param>
        /// <param name=”password”>Password ingresado</param>
        /// <returns>
        /// True:Usuario valido
        /// False Usuario Invalido
        /// </returns>
        private bool Isvalid(string Email, string password)
        {
            bool Isvalid = false;
            using (var db = new BaseDatos.BDPeluqueriaEntities1())
            {
                var user = db.Usuarios.FirstOrDefault(u => u.correo == Email); //consultar el primer registro con los el email del usuario
                if (user != null)
                {
                    if (user.contraseña == password) //Verificar password del usuario
                    {
                        Isvalid = true;
                    }
                }
            }
            return Isvalid;
        }
    }

}