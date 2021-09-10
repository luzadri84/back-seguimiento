using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppDocumentosTipoEntidades
    {
        public decimal TdoId { get; set; }
        public int TipId { get; set; }
        public string TdoNs { get; set; }
        public decimal? TdoOrden { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
        public bool? Obligatorio { get; set; }

        public virtual AppTipoDocumentos Tdo { get; set; }
        public virtual AppTiposEntidades Tip { get; set; }
    }
}
