using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    
    public  class AppTipoDocumentosDto
    {
        public AppTipoDocumentosDto()
        {

        }
        public decimal TdoId { get; set; }
        public string TdoNombre { get; set; }
        public string TdoObservacion { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }


    }
}
