using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppIndicadores
    {
        public AppIndicadores()
        {
            AppIndicadoresLinea = new HashSet<AppIndicadoresLinea>();
            AppValoresIndicador = new HashSet<AppValoresIndicador>();
        }

        public decimal IndId { get; set; }
        public string IndNombre { get; set; }
        public string IndDescripcion { get; set; }
        public string IndFormula { get; set; }
        public decimal? IndTipo { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual ICollection<AppIndicadoresLinea> AppIndicadoresLinea { get; set; }
        public virtual ICollection<AppValoresIndicador> AppValoresIndicador { get; set; }
    }
}
