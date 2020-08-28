using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalNoticias.ETL
{
    public class clsComentarios
    {
        public long IdComentario { get; set; }
        public long IdUsuario { get; set; }
        public long IdNoticia { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Texto { get; set; }

        public Noticia Noticia { get; set; }
        public Usuario Usuario { get; set; }
    }
}