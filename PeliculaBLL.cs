using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MoviesManagerWPF
{
    class PeliculaBLL
    {
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var Pelicula = contexto.Peliculas.Find(id);
                if (Pelicula != null)
                {
                    contexto.Peliculas.Remove(Pelicula);//remover la entidad mas las que enel agrego
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Peliculas Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Peliculas Pelicula;

            try
            {
                Pelicula = contexto.Peliculas.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return Pelicula;


        }
        public static bool Guardar(Peliculas Pelicula)
        {
            if (!Existe(Pelicula.PeliculaId))//si no existe insertamos
                return Insertar(Pelicula);
            else
                return Modificar(Pelicula);
        }
        public static bool Modificar(Peliculas Pelicula)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Pelicula).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Insertar(Peliculas Pelicula)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //ana te cuento un c=secreto
                contexto.Peliculas.Add(Pelicula);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        public static List<Peliculas> GetList(Expression<Func<Peliculas, bool>> expresion)
        {
            Contexto contexto = new Contexto();
            List<Peliculas> lista = new List<Peliculas>();
            try
            {
                lista = contexto.Peliculas.Where(expresion).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Peliculas
                .Any(e => e.PeliculaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado; //si
        }
    }
}
