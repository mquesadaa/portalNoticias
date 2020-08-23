using PortalNoticias.ETL;
using PortalNoticias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalNoticias.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult RegistroIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult confirmacionRegistro()
        {
            return View();
        }

        [HttpPost]

        public ActionResult RegistroIndex(loginClase registro)
        {
            if (registro.Nombre != null && registro.NombreUsuario != null
                && registro.Apellido1 != null && registro.Apellido2 != null
                && registro.Clave != null)
            {  //INSERT
                using (var contextoBD = new PortalNoticiasEntities())
                {
                    Usuario user = new Usuario();
                    user.IdUsuario = 0;
                    user.NombreUsuario = registro.NombreUsuario;
                    user.TipoUsuario = 2; //2. rol usuario. Si se registra mediante la página va a ser siempre tipo 2, para ser tipo 1 (admin) solo se puede si un administrador crea el usuario
                    user.Nombre = registro.Nombre;
                    user.Apellido1 = registro.Apellido1;
                    user.Apellido2 = registro.Apellido2;
                    user.Clave = registro.Clave;

                    contextoBD.Usuario.Add(user);
                    contextoBD.SaveChanges();
                }
                return RedirectToAction("confirmacionRegistro", "Login");
            }
            else
            {
                return RedirectToAction("LoginController", "Login");
            }
        }
    }

    
}