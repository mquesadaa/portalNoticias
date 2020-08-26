using PortalNoticias.ETL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PortalNoticias.Models
{
    public class modeloArchivo
    {
        public int AgregarArchivo(clsArchivo archivo)
        {
            using (var conn = new PortalNoticiasEntities())
            {
                Archivo archivoBd = new Archivo
                {
                    IdNoticia = archivo.IdNoticia,
                    Ruta = archivo.Ruta,
                    Tipo = archivo.Tipo
                };
                conn.Archivo.Add(archivoBd);
                return conn.SaveChanges();
            }
        }

        public int ActualizarArchivo(clsArchivo archivo)
        {
            using (var conn = new PortalNoticiasEntities())
            {
                Archivo archivoBd = new Archivo
                {
                    IdArchivo = archivo.IdArchivo,
                    IdNoticia = archivo.IdNoticia,
                    Ruta = archivo.Ruta,
                    Tipo = archivo.Tipo
                };
                conn.Archivo.AddOrUpdate(archivoBd);
                return conn.SaveChanges();
            }
        }

        public int BorrarArchivo(Archivo archivo)
        {
            using (var conn = new PortalNoticiasEntities())
            {
                conn.Archivo.Attach(archivo);
                conn.Archivo.Remove(archivo);
                return conn.SaveChanges();
            }
        }

        public List<Archivo> ObtenerArchivos()
        {
            using (var conn = new PortalNoticiasEntities())
            {
                var resultado = (from x in conn.Archivo
                                 select x).ToList();
                return resultado;
            }
        }

        public Archivo ObtenerArchivoPorId(int id)
        {
            using (var conn = new PortalNoticiasEntities())
            {
                var resultado = (from x in conn.Archivo
                                 where x.IdNoticia == id
                                 select x).Single();
                return resultado;
            }
        }
    }
}