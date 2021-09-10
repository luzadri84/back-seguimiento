using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_PROYECTOS_CRONOGRAMA")]
    public partial class AppCronograma
    {
        
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column("CPR_ID", TypeName = "decimal(18,0)")]
        public decimal CprId { get; set; }
        [Column("CPR_FECHA_INICIO", TypeName = "datetime")]
        public DateTime? CprFechaInicio { get; set; }
        [Column("CPR_FECHA_FINAL", TypeName = "datetime")]
        public DateTime? CprFechaFinal { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal? ProId { get; set; }
        [Column("CPR_ACTIVIDAD")]
        [StringLength(500)]
        public string CprActividad { get; set; }
        [Column("CPR_META")]
        [StringLength(30)]
        public string CprMeta { get; set; }
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

        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(AppProyectos.AppCronograma))]
        public virtual AppProyectos Pro { get; set; }
    }
}
