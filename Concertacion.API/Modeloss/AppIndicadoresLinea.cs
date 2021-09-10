using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppIndicadoresLinea
    {
        public decimal IndId { get; set; }
        public decimal LinId { get; set; }
        public decimal? IndOrder { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppIndicadores Ind { get; set; }
        public virtual AppLineas Lin { get; set; }
    }
}
