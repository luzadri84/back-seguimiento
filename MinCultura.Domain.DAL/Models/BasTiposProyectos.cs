using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("BAS_TIPOS_PROYECTOS")]
    public partial class BasTiposProyectos
    {
        [Key]
        [Column("TIP_ID", TypeName = "numeric(18, 0)")]
        public decimal TipId { get; set; }
        [Required]
        [Column("TIP_NOMBRE")]
        [StringLength(50)]
        public string TipNombre { get; set; }
        [Required]
        [Column("TIP_INSTANCIA")]
        [StringLength(1)]
        public string TipInstancia { get; set; }
        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        public decimal VigId { get; set; }

        [ForeignKey(nameof(VigId))]
        [InverseProperty(nameof(AppVigencias.BasTiposProyectos))]
        public virtual AppVigencias Vig { get; set; }
    }
}
