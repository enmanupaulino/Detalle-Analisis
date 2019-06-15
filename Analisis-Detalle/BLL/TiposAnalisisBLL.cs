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
     public class TiposAnalisisBLL
    {
        public static bool Guardar(TiposAnalisis tiposanalisis)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.tiposanalisis.Add(tiposanalisis) != null)
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
        public static bool Modificar(TiposAnalisis tiposanalisis)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(tiposanalisis).State = System.Data.Entity.EntityState.Modified;
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
        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Eliminar = contexto.tiposanalisis.Find(Id);
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
        public static TiposAnalisis Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            TiposAnalisis tiposanalisis = new TiposAnalisis();
            try
            {
                tiposanalisis = contexto.tiposanalisis.Find(Id);
            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return tiposanalisis;

        }
        public static List<TiposAnalisis> GetList(Expression<Func<TiposAnalisis, bool>> tiposanalisis)

        {
            List<TiposAnalisis> Lista = new List<TiposAnalisis>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.tiposanalisis.Where(tiposanalisis).ToList();
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
