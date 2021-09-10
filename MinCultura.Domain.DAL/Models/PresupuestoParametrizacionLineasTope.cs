using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("PRESUPUESTO_PARAMETRIZACION_LINEAS_TOPE")]
    public partial class PresupuestoParametrizacionLineasTope
    {
        public PresupuestoParametrizacionLineasTope()
        {
            //AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            //AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        [Key]
        [Column("PPL_ID", TypeName = "int")]
        public int PPL_ID { get; set; }

        [Column("ZON_ID")]
        //[StringLength(2000)]
        public string ZON_ID { get; set; }

        [Column("LIN_ID", TypeName = "numeric(18, 0)")]
        //[StringLength(1000)]
        public decimal LIN_ID { get; set; }

        //[Required]
        [Column("VALOR_TOPE_PRESUPUESTO", TypeName = "numeric(18, 0)")]
        //[StringLength(100)]
        public decimal VALOR_TOPE_PRESUPUESTO { get; set; }

        

        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
