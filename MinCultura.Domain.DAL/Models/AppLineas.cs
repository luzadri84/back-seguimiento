using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_LINEAS")]
    public partial class AppLineas
    {
        public AppLineas()
        {
            AppIndicadoresLinea = new HashSet<AppIndicadoresLinea>();
            AppVariables = new HashSet<AppVariables>();
        }

        [Key]
        [Column("LIN_ID", TypeName = "decimal(18, 0)")]
        public decimal LinId { get; set; }
        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        public decimal VigId { get; set; }
        [Column("LIN_NOMBRE")]
        [StringLength(1000)]
        public string LinNombre { get; set; }
        [Column("LIN_DESCRIPCION")]
        [StringLength(2000)]
        public string LinDescripcion { get; set; }
        [Column("LIN_DURACION_MINIMA")]
        public int? LinDuracionMinima { get; set; }
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

        [InverseProperty("Lin")]
        public virtual ICollection<AppIndicadoresLinea> AppIndicadoresLinea { get; set; }
        [InverseProperty("Lin")]
        public virtual ICollection<AppVariables> AppVariables { get; set; }

        public virtual ICollection<AppIndicadorLineaCategoriaMunicipio> AppIndicadorLineaCategoriaMunicipio { get; set; }
    }
}
