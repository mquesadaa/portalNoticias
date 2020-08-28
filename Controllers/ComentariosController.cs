using PortalNoticias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalNoticias.Controllers
{
    [Authorize(Roles ="Usuario")]
    public class ComentariosController : Controller
    {
        public ActionResult SaveDetailedInfo(int id, string txt)
        {
            //UsuarioCorriente
            //ViewData["IdUsuario"] = 2;

            Comentario comentario = new Comentario
            {
                Fecha = DateTime.Now,
                IdNoticia = id,
                IdUsuario = (long)Session["userID"],
                Texto =txt

            };


            try
            {
                modeloComentario bd = new modeloComentario();
                int a = bd.AgregarComentario(comentario);
                if (a!=0)
                {

                    return Json(new { status = "Success", message = "Comentario agregado con exito" });
                }
                else
                {
                   
                    return Json(new { status = "Success", message = "No se almaceno el comentario" });
                }
                
            }catch (Exception e)
            {
                return Json(new { status = "Error", message = "No se pudo conectar a la base de datos" });
            }
        }

        [AllowAnonymous]
        // GET: Comentarios
        public ActionResult _Comentarios(long idNoticia)
        {
            modeloComentario bd = new modeloComentario();
            List<Comentario> cometarios = bd.ObtenerComentarios(idNoticia);


            return PartialView(cometarios);
        }





    }


   
}