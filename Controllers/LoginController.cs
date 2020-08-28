using PortalNoticias.ETL;
using PortalNoticias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PortalNoticias.Controllers
{
    public class LoginController : Controller
    {
        //[HttpGet]
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
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Autherize(UserViewModel userModel)
        {
            PortalNoticiasEntities DbContext = new PortalNoticiasEntities();
            
            var userDetails = DbContext.Set<Usuario>().Where(u => u.NombreUsuario.Equals(userModel.UserName) && u.Clave.Equals(userModel.Password)).FirstOrDefault();
            if (userDetails == null)
            {
                userModel.LoginErrorMessage = "Nombre de Usuario o Password Incorrectos";
                return View("Index", userModel);
            }
            else
            {
                //Variables de sesion
                Session["userID"] = userDetails.IdUsuario;
                Session["userName"] = userDetails.NombreUsuario;
                Session["tipoUsuario"] = userDetails.TipoUsuario;
                // 
                var authTicket = new FormsAuthenticationTicket(userDetails.NombreUsuario, true, 100000);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                            FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);
                var name = User.Identity.Name; // line 4
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
           // int userId = (int)Session["userID"];
            Session.Clear();
            Session.Abandon();



            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
            return RedirectToAction("Index", "Home");
        }
    }

    
}