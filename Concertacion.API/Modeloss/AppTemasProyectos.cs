using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppTemasProyectos
    {
        public int Id { get; set; }
        public int? TemId { get; set; }
        public decimal? ProId { get; set; }

        public virtual AppProyectos Pro { get; set; }
        public virtual AppTemas Tem { get; set; }
    }
}
