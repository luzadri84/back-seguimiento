using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppValoresIndicador
    {
        public decimal IndId { get; set; }
        public decimal ProId { get; set; }
        public decimal? ValValor { get; set; }
        public string ValValorTexto { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppIndicadores Ind { get; set; }
        public virtual AppProyectos Pro { get; set; }
    }
}
