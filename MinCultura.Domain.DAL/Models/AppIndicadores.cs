using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_INDICADORES")]
    public partial class AppIndicadores
    {
        public AppIndicadores()
        {
            AppIndicadoresLinea = new HashSet<AppIndicadoresLinea>();
        }

        [Key]
        [Column("IND_ID", TypeName = "numeric(18, 0)")]
        public decimal IndId { get; set; }
        [Column("IND_NOMBRE")]
        [StringLength(5000)]
        public string IndNombre { get; set; }
        [Column("IND_DESCRIPCION")]
        [StringLength(1000)]
        public string IndDescripcion { get; set; }
        [Column("IND_FORMULA")]
        [StringLength(100)]
        public string IndFormula { get; set; }
        [Column("IND_TIPO", TypeName = "numeric(18, 0)")]
        public decimal? IndTipo { get; set; }
        [Required]
        [Column("USU_CREO")]
        [StringLength(100)]
        public string UsuCreo { get; set; }
        [Column("USU_MODIFICO")]
        [StringLength(100)]
        public string UsuModifico { get; set; }
        [Column("FEC_CREO", TypeName = "datetime")]
        public DateTime FecCreo { get; set; }
        [Column("FEC_MODIFICO", TypeName = "datetime")]
        public DateTime? FecModifico { get; set; }

        [InverseProperty("Ind")]
        public virtual ICollection<AppIndicadoresLinea> AppIndicadoresLinea { get; set; }
        public virtual ICollection<AppIndicadorLineaCategoriaMunicipio> AppIndicadorLineaCategoriaMunicipio { get; set; }
    }
}
