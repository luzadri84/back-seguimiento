using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_ESTADO_CONTRATACION")]
    public partial class AppEstadoContratacion
    {
        public AppEstadoContratacion()
        {
            AppContratacion = new HashSet<AppContratacion>();
        }

        [Key]
        [Column("ESC_ID", TypeName = "numeric(18, 0)")]
        public decimal EscId { get; set; }
        [Column("ESC_NOMBRE")]
        [StringLength(50)]
        public string EscNombre { get; set; }

        [InverseProperty("Esc")]
        public virtual ICollection<AppContratacion> AppContratacion { get; set; }
    }
}
