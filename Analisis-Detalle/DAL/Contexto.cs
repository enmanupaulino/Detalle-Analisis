using Analisis_Detalle.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analisis_Detalle.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Analisis>analisis { get; set; }
        public DbSet<TiposAnalisis> tiposanalisis { get; set; }
        public Contexto() : base("ConStr")
        {

        }
    }
}
