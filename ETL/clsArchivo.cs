using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalNoticias.ETL
{
    public class clsArchivo
    {
        [Display(Name ="N°")]
        public long IdArchivo { get; set; }
        [Display(Name ="N° de noticia")]
        public long IdNoticia { get; set; }
        [Display(Name ="Archivo")]
        public string Ruta { get; set; }
        public bool Tipo { get; set; }
    }
}