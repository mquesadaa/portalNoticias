using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalNoticias.ETL
{
    public class loginClase
    {
        public string IdUsuario { get; set; }
        [Display(Name = "Nombre de usuario:")]
        public string NombreUsuario { get; set; }
        public string TipoUsuario { get; set; }
        [Display(Name = "Nombre completo:")]
        public string Nombre { get; set; }
        [Display(Name = "Primer apellido:")]
        public string Apellido1 { get; set; }
        [Display(Name = "Segundo apellido:")]
        public string Apellido2 { get; set; }
        [Display(Name = "Contraseña:")]
        public string Clave { get; set; }
    }
}