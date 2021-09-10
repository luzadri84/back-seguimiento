using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AdmPerfilesUsuarios
    {
        public decimal PerId { get; set; }
        public decimal UsuId { get; set; }

        public virtual AdmPerfiles Per { get; set; }
    }
}
