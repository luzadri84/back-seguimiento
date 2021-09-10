using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_RADICADO_PROYECTOS")]
    public partial class AppRadicadoProyectos
    {
        
        [Key]
        [Column("NUMERO_RADICADO", TypeName = "int")]
        public int NumeroRadicado { get; set; }

        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal ProId { get; set; }

        [Column("VIG_ID", TypeName = "decimal(18, 0)")]
        public decimal VigId { get; set; }

        [Column("FECHA_REGISTRO", TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [Column("RADICADO_PROYECTO")]
        [StringLength(20)]
        public string RadicadoProyecto { get; set; }

        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(AppProyectos.AppRadicadoProyectos))]
        public virtual AppProyectos Pro { get; set; }
    }
}
