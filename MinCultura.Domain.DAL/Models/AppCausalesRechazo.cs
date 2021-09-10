using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_CAUSALES_RECHAZO")]
    public partial class AppCausalesRechazo
    {
        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        public decimal VigId { get; set; }
        [Key]
        [Column("CAU_ID", TypeName = "numeric(18, 0)")]
        public decimal CauId { get; set; }
        [Required]
        [Column("CAU_DESCRIPCION")]
        [StringLength(1000)]
        public string CauDescripcion { get; set; }
        [Required]
        [Column("CAU_NOMBRE")]
        [StringLength(100)]
        public string CauNombre { get; set; }

        [ForeignKey(nameof(VigId))]
        [InverseProperty(nameof(AppVigencias.AppCausalesRechazo))]
        public virtual AppVigencias Vig { get; set; }
    }
}
