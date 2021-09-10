using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppTipoDocumentosValores
    {
        public decimal TdvId { get; set; }
        public decimal? TdoId { get; set; }
        public decimal? ProId { get; set; }
        public string TdvNombre { get; set; }
        public int? TdvNumeroPaginas { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
        public string TdvRutaAdjunto { get; set; }

        public virtual AppProyectos Pro { get; set; }
        public virtual AppTipoDocumentos Tdo { get; set; }
    }
}
