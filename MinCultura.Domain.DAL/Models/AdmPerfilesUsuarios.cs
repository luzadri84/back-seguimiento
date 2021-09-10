using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_COMPONENTES")]
    public partial class AdmPerfilesUsuarios
    {
        
        [Column("PER_ID", TypeName = "numeric(18, 0)")]
        public decimal PerId { get; set; }
        [Column("USU_ID", TypeName = "numeric(18, 0)")]
        public decimal UsuId { get; set; }

        public virtual AdmPerfiles Per { get; set; }
    }
}
