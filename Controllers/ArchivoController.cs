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
    public class ArchivoController : Controller
    {
        public ActionResult Lista()
        {
            modeloArchivo bd = new modeloArchivo();
            var lista = bd.ObtenerArchivos();
            return View(lista);
        }

        public ActionResult ConsultarId(int id)
        {
            modeloArchivo bd = new modeloArchivo();
            var lista = bd.ObtenerArchivoPorId(id);
            return View(lista);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Crear(clsArchivo archivo)
        {
            if (archivo.Tipo)
            {
                modeloArchivo bd = new modeloArchivo();
                if (bd.AgregarArchivo(archivo) > 0)
                {
                    return Json(new { ok = true, mensaje = archivo }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                if (Request.Files.Count > 0)
                {
                    try
                    {
                        HttpFileCollectionBase files = Request.Files;

                        HttpPostedFileBase file = files[0];
                        string fname;
                        fname = file.FileName;

                        fname = Path.Combine(Server.MapPath("~/Archivos/"), fname);
                        var flocalName = "../Archivos/" + file.FileName;
                        file.SaveAs(fname);

                        archivo.Ruta = flocalName;
                        modeloArchivo bd = new modeloArchivo();
                        if (bd.AgregarArchivo(archivo) > 0)
                        {
                            return Json(new { ok = true, mensaje = archivo }, JsonRequestBehavior.AllowGet);
                        }
                        return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);

                    }
                    catch (Exception ex)
                    {
                        return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);
                }
            }
            
        }

        public ActionResult Actualizar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Actualizar([Bind]clsArchivo archivo)
        {
            if (archivo.Tipo)
            {
                modeloArchivo bd = new modeloArchivo();
                if (bd.ActualizarArchivo(archivo) > 0)
                {
                    return Json(new { ok = true, mensaje = archivo }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                if (Request.Files.Count > 0)
                {
                    try
                    {
                        HttpFileCollectionBase files = Request.Files;

                        HttpPostedFileBase file = files[0];
                        string fname;
                        fname = file.FileName;

                        fname = Path.Combine(Server.MapPath("~/Archivos/"), fname);
                        var flocalName = "../Archivos/" + file.FileName;
                        file.SaveAs(fname);
                        archivo.Ruta = flocalName;

                        modeloArchivo bd = new modeloArchivo();
                        if (bd.ActualizarArchivo(archivo) > 0)
                        {
                            return Json(new { ok = true, mensaje = archivo }, JsonRequestBehavior.AllowGet);
                        }
                        return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);

                    }
                    catch (Exception ex)
                    {
                        return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { ok = false, mensaje = "No se agregó el archivo. Intenta con otro, este probablemente ya existe en la base de datos" }, JsonRequestBehavior.AllowGet);
                }
            }
                
            
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            try
            {
                modeloArchivo bd = new modeloArchivo();
                var noticia = bd.ObtenerArchivoPorId(id);
                if (bd.BorrarArchivo(noticia) > 0)
                {
                    return Json(new { ok = true, mensaje = noticia }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { ok = false, mensaje = "No se agregó el archivo" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}