using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Analisis_Detalle.Entidades
{
    public class TiposAnalisis
    {
        [Key]
        public int TiposId { get; set; }
        public string Descripcion { get; set; }

        public virtual List<AnalisisDetalle>Analisi { get; set; }

        public TiposAnalisis()
        {
            TiposId = 0;
            Descripcion = string.Empty;
            Analisi = new List<AnalisisDetalle>();
        }
    }
}