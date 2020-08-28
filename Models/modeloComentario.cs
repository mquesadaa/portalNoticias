using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalNoticias.Models
{
    public class modeloComentario
    {
        public List<Comentario> ObtenerComentarios(long idNoticia)
        {
            PortalNoticiasEntities conn = new PortalNoticiasEntities();

            var resultado = (from x in conn.Comentario
                             where x.IdNoticia == idNoticia
                             select x).ToList();
            return resultado;

        }


        public int AgregarComentario(Comentario comentario)
        {
            using (var conn = new PortalNoticiasEntities())
            {
               
                conn.Comentario.Add(comentario);
               return  conn.SaveChanges();

                
            }
        }
    }



    
}