using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_VALORES_INDICADOR_LINEA_CATEGORIA_MUNICIPIO")]
    public class AppValoresIndicadorLineaCategoriaMunicipio
    {
        public decimal VilcmId { get; set; }
        public decimal IlcmId { get; set; }
        public decimal ProId { get; set; }
        public decimal? ValValor { get; set; }
        public string ValValorTexto { get; set; }
        public DateTime? FecModifico { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        
        public virtual AppIndicadorLineaCategoriaMunicipio Ilcm { get; set; }
        public virtual AppProyectos Pro { get; set; }

    }
}
