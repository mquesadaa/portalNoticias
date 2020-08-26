using PortalNoticias.ETL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Management;

namespace PortalNoticias.Models
{
    public class modeloNoticia
    {
        public long AgregarNoticia(clsNoticia noticia)
        {
            using (var conn = new PortalNoticiasEntities())
            {
                Noticia noticiaBd = new Noticia
                {
                    IdUsuario = noticia.IdUsuario,
                    Titulo = noticia.TituloNoticia,
                    Texto = noticia.TextoNoticia,
                    Fecha = noticia.FechaNoticia,
                    TipoNoticia = noticia.TipoNoticia
                };
                conn.Noticia.Add(noticiaBd);
                conn.SaveChanges();

                return noticiaBd.IdNoticia;
            }
        }

        public long ActualizarNoticia(clsNoticia noticia)
        {
            using (var conn = new PortalNoticiasEntities())
            {
                Noticia noticiaBd = new Noticia
                {
                    IdNoticia = noticia.IdNoticia,
                    IdUsuario = noticia.IdUsuario,
                    Titulo = noticia.TituloNoticia,
                    Texto = noticia.TextoNoticia,
                    Fecha = noticia.FechaNoticia,
                    TipoNoticia = noticia.TipoNoticia
                };
                conn.Noticia.AddOrUpdate(noticiaBd);
                conn.SaveChanges();
                return noticia.IdNoticia;
            }
        }

        public int BorrarNoticia(Noticia noticia)
        {
            using (var conn = new PortalNoticiasEntities())
            {
                modeloArchivo bdar = new modeloArchivo();
                var archivoABorrar = (from item in (bdar.ObtenerArchivos())
                                      where item.IdNoticia == noticia.IdNoticia
                                      select item.IdArchivo).SingleOrDefault();

                if(archivoABorrar != 0)
                {
                    //Borrar archivo relacionado a la noticia
                    bdar.BorrarArchivo(new Archivo { IdArchivo = archivoABorrar });
                }
                
                conn.Noticia.Attach(noticia);
                conn.Noticia.Remove(noticia);
                return conn.SaveChanges();
            }
        }

        public List<Noticia> ObtenerNoticias()
        {
            using (var conn = new PortalNoticiasEntities())
            {
                var resultado = (from x in conn.Noticia
                                 select x).ToList();
                return resultado;
            }
        }

        public Noticia ObtenerNoticiaPorId(int id)
        {
            using (var conn = new PortalNoticiasEntities())
            {
                var resultado = (from x in conn.Noticia
                                 where x.IdNoticia == id
                                 select x).Single();
                return resultado;
            }
        }

    }
}