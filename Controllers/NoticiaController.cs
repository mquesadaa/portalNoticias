using PortalNoticias.ETL;
using PortalNoticias.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalNoticias.Controllers
{
    public class NoticiaController : Controller
    {
        #region Noticia
        public ActionResult Lista()
        {
            modeloNoticia bd = new modeloNoticia();
            var lista = bd.ObtenerNoticias();
            return View(lista);
        }

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

            if(archivo != null)
            {
                var extension = string.Empty;
                extension = Path.GetExtension(archivo.Ruta);

                ViewData["extension"] = (archivo.Tipo ? "video" : "imagen");

            }
            else
            {
                ViewData["extension"] = " ";
            }

            return View("Detalle",lista);
        }

        public ActionResult Crear()
        {
            ViewData["IdUsuario"] = 1; //Administrador
            return View();
        }

        [HttpPost]
        public JsonResult Crear(clsNoticia noticia)
        {
            try
            {
                modeloNoticia bd = new modeloNoticia();
                var idNoticia = bd.AgregarNoticia(noticia);
                if ( idNoticia > 0)
                {
                    return Json(new { ok = true, idNoticia }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Actualizar(int idNoticia)
        {
            modeloNoticia bd = new modeloNoticia();
            ViewData["IdUsuario"] = 1; //Administrador

            modeloArchivo bdAr = new modeloArchivo();


            ViewData["Archivo"] = (from item in (bdAr.ObtenerArchivos())
                                   where item.IdNoticia == idNoticia
                                   select new clsArchivo 
                                   {
                                    IdArchivo = item.IdArchivo,
                                    IdNoticia = item.IdNoticia,
                                    Ruta = item.Ruta,
                                    Tipo = item.Tipo
                                   }).SingleOrDefault();

            var res = bd.ObtenerNoticiaPorId(idNoticia);
            var lista = new clsNoticia
            {
                IdNoticia = res.IdNoticia,
                TextoNoticia = res.Texto,
                TipoNoticia = res.TipoNoticia,
                TituloNoticia = res.Titulo,
                FechaNoticia = res.Fecha,
                IdUsuario  = 1
            };
            return View(lista);
        }

        [HttpPost]
        public JsonResult Actualizar(clsNoticia noticia)
        {
            try
            {
                modeloNoticia bd = new modeloNoticia();
                var idNoticia = bd.ActualizarNoticia(noticia);
                if (idNoticia > 0)
                {
                    return Json(new { ok = true, idNoticia }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            try
            {
                modeloNoticia bd = new modeloNoticia();
                if (bd.BorrarNoticia(new Noticia {IdNoticia = id }) > 0)
                {
                    return Json(new { ok = true, mensaje = "Eliminado" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

    }
}