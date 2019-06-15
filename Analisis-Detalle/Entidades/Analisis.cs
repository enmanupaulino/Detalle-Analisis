using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analisis_Detalle.Entidades
{
   public  class Analisis
    {
        [Key]
        public int AnalisisId { get; set; }
        public string UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<AnalisisDetalle> Analisi { get; set; }

        public Analisis()
        {
            AnalisisId = 0;
            UsuarioId = string.Empty;
            Fecha = DateTime.Now;
            Analisi = new List<AnalisisDetalle>();
        }

    }
}
