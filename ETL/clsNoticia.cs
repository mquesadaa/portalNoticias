using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalNoticias.ETL
{
    public class clsNoticia
    {
        [Display(Name ="N° noticia")]
        public long IdNoticia { get; set; }
        public long IdUsuario { get; set; }
        [Display(Name = "Título")]
        public string TituloNoticia { get; set; }
        [Display(Name = "Texto")]
        public string TextoNoticia { get; set; }
        [Display(Name ="Fecha")]
        public DateTime FechaNoticia { get; set; }
        [Display(Name = "Tipo de noticia")]
        public string TipoNoticia { get; set; }

    }
}