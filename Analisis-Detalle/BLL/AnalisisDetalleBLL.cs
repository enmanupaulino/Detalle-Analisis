using Analisis_Detalle.DAL;
using Analisis_Detalle.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analisis_Detalle.BLL
{
    public class AnalisisDetalleBLL
    {
        public static bool Guardar(AnalisisDetalle analisisDetalle)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.analisisDetalle.Add(analisisDetalle) != null)
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
        {
            bool paso = false;
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

    }

}
