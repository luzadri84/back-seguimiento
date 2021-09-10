using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppTipoDocumentos
    {
        public AppTipoDocumentos()
        {
            AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        public decimal TdoId { get; set; }
        public string TdoNombre { get; set; }
        public string TdoObservacion { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
