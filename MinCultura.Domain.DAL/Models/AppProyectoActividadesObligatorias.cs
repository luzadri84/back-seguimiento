using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_PROYECTO_ACTIVIDADES_OBLIGATORIAS")]
    public partial class AppProyectoActividadesObligatorias
    {

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("PAO_ID", TypeName = "decimal(18, 0)")]
        public decimal PaoId { get; set; }
        [Column("ACT_ID", TypeName = "decimal(18, 0)")]
        public decimal ActId { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal ProId { get; set; }
        [Column("ACT_FECHA_INICIO", TypeName = "datetime")]
        public DateTime? ActFechaInicio { get; set; }
        [Column("ACT_FECHA_FINAL", TypeName = "datetime")]
        public DateTime? ActFechaFinal { get; set; }
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

        [ForeignKey(nameof(ActId))]
        [InverseProperty(nameof(AppActividadesObligatorias.AppProyectosActObligatorias))]
        public virtual AppActividadesObligatorias ActObl { get; set; }

    }
}
