using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_INDICADOR_LINEA_CATEGORIA_MUNICIPIO")]
    public class AppIndicadorLineaCategoriaMunicipio
    {

        public AppIndicadorLineaCategoriaMunicipio()
        {
            AppValoresIndicadorLineaCategoriaMunicipio = new HashSet<AppValoresIndicadorLineaCategoriaMunicipio>();
        }

        public decimal IlcmId { get; set; }
        public decimal IndId { get; set; }
        public decimal LinId { get; set; }
        public decimal IdZonCategoria { get; set; }
        public decimal? IlmOrder { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppIndicadores Ind { get; set; }
        public virtual AppLineas Lin { get; set; }
        public virtual ICollection<AppValoresIndicadorLineaCategoriaMunicipio> AppValoresIndicadorLineaCategoriaMunicipio { get; set; }
    }
}
