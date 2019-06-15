using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analisis_Detalle.Entidades
{
    public class AnalisisDetalle
    {
        [Key]
        public int Id { get; set; }
        public int  AnalisisId { get; set; }
        public int  TiposId { get; set; }
        public string  Resultado { get; set; }
        public AnalisisDetalle()
        {
            Id = 0;
            AnalisisId = 0;
            TiposId = 0;
            Resultado = string.Empty;

        }
    }
}
