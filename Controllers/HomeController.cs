using PortalNoticias.ETL;
using PortalNoticias.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalNoticias.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            string tipoNoticia = "";
            var listaNoticias = new List<clsNoticiaArchivo>();
            modeloNoticia mn = new modeloNoticia();
            modeloArchivo ma = new modeloArchivo();

            if (tipoNoticia.Equals(""))
            {
                listaNoticias = (from noticias in (mn.ObtenerNoticias())
                                 from archivos in (ma.ObtenerArchivos())
                                 where noticias.TipoNoticia != "" && noticias.IdNoticia == archivos.IdNoticia
                                 orderby noticias.Fecha
                                 select new clsNoticiaArchivo
                                 {
                                     Archivo = archivos,
                                     Noticia = noticias
                                 }).ToList();
                ViewBag.Etiqueta = "Home";
            }
            else
            {
                listaNoticias = (from noticias in (mn.ObtenerNoticias())
                                 from archivos in (ma.ObtenerArchivos())
                                 where noticias.TipoNoticia == tipoNoticia && noticias.IdNoticia == archivos.IdNoticia
                                 orderby noticias.Fecha
                                 select new clsNoticiaArchivo
                                 {
                                     Archivo = archivos,
                                     Noticia = noticias
                                 }).ToList();
                ViewBag.Etiqueta = tipoNoticia;
            }

            return View(listaNoticias);
        }


        /*  public ActionResult Index(string tipoNoticia = "")
          {
              var listaNoticias = new List<clsNoticiaArchivo>();
              modeloNoticia mn = new modeloNoticia();
              modeloArchivo ma = new modeloArchivo();

              if (tipoNoticia.Equals(""))
              {
                  listaNoticias = (from noticias in (mn.ObtenerNoticias())
                                   from archivos in (ma.ObtenerArchivos())
                                   where noticias.TipoNoticia != "" && noticias.IdNoticia == archivos.IdNoticia
                                   orderby noticias.Fecha
                                   select new clsNoticiaArchivo 
                                   { 
                                      Archivo = archivos,
                                      Noticia = noticias
                                   }).ToList();
                  ViewBag.Etiqueta = "Home";
              }
              else
              {
                  listaNoticias = (from noticias in (mn.ObtenerNoticias())
                                   from archivos in (ma.ObtenerArchivos())
                                   where noticias.TipoNoticia == tipoNoticia && noticias.IdNoticia == archivos.IdNoticia
                                   orderby noticias.Fecha
                                   select new clsNoticiaArchivo
                                   {
                                       Archivo = archivos,
                                       Noticia = noticias
                                   }).ToList();
                  ViewBag.Etiqueta = tipoNoticia;
              }

              return View(listaNoticias);
          }*/
        [AllowAnonymous]
        public ActionResult ConsultarId(int id)
        {
            modeloNoticia bd = new modeloNoticia();
            var res = bd.ObtenerNoticiaPorId(id);
            var lista = new clsNoticia
            {
                IdNoticia = res.IdNoticia,
                TextoNoticia = res.Texto,
                TipoNoticia = res.TipoNoticia,
                TituloNoticia = res.Titulo,
                FechaNoticia = res.Fecha,
                IdUsuario = 1
            };
            modeloArchivo bdAr = new modeloArchivo();
            var archivo = (from item in (bdAr.ObtenerArchivos())
                           where item.IdNoticia == id
                           select new clsArchivo
                           {
                               IdArchivo = item.IdArchivo,
                               IdNoticia = item.IdNoticia,
                               Ruta = item.Ruta,
                               Tipo = item.Tipo
                           }).SingleOrDefault();
            ViewData["Archivo"] = archivo;

            if (archivo != null)
            {
                var extension = string.Empty;
                extension = Path.GetExtension(archivo.Ruta);

                ViewData["extension"] = (archivo.Tipo ? "video" : "imagen");

            }
            else
            {
                ViewData["extension"] = " ";
            }
            ViewBag.Etiqueta = lista.TipoNoticia;
            return View("Detalle", lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        //--------------------------------------------Cpmentarios------------------------------------------------




        //------------------------------------------fin comentarios..............................................
    }
}