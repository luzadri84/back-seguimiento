using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("BAS_DEPENDENCIAS")]
    public partial class BasDependencias
    {
        public BasDependencias()
        {
            AppContratacion = new HashSet<AppContratacion>();
        }

        [Key]
        [Column("DEP_ID", TypeName = "numeric(18, 0)")]
        public decimal DepId { get; set; }
        [Column("DEP_NOMBRE")]
        [StringLength(100)]
        public string DepNombre { get; set; }
        [Column("DEP_DIRECCION")]
        [StringLength(100)]
        public string DepDireccion { get; set; }
        [Column("DEP_TELEFONOS")]
        [StringLength(100)]
        public string DepTelefonos { get; set; }
        [Column("SEC_ID", TypeName = "numeric(18, 0)")]
        public decimal? SecId { get; set; }
        [Column("ARE_ID", TypeName = "numeric(18, 0)")]
        public decimal? AreId { get; set; }

        [InverseProperty("Dep")]
        public virtual ICollection<AppContratacion> AppContratacion { get; set; }
    }
}
