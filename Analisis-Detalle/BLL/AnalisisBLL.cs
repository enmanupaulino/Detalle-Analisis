using Analisis_Detalle.DAL;
using Analisis_Detalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Analisis_Detalle.BLL
{
    public class AnalisisBLL
    {
        public static bool Guardar(Analisis analisis)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.analisis.Add(analisis) != null)
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
        public static bool Modificar(Analisis analisis)
        { bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(analisis).State = System.Data.Entity.EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
                
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
        public static bool Eliminar (int Id) {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Eliminar = contexto.analisis.Find(Id);
                contexto.Entry(Eliminar).State = System.Data.Entity.EntityState.Deleted;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally { contexto.Dispose(); }
            return paso;
        }
        public static Analisis Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Analisis analisis = new Analisis();
            try
            {
                analisis = contexto.analisis.Find(Id);
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return analisis;

        }

        public static List<Analisis> GetList(Expression<Func<Analisis, bool>> analisis)
       
        {
            List<Analisis> Lista = new List<Analisis>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.analisis.Where(analisis).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return Lista;
        }
    }
}
