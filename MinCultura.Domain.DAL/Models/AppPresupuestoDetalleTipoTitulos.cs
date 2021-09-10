using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_PRESUPUESTO_DETALLE_TIPO_TITULOS")]
    public partial class AppPresupuestoDetalleTipoTitulos
    {
        public AppPresupuestoDetalleTipoTitulos()
        {
            //AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            //AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        [Key]
        [Column("ATT_ID", TypeName = "int")]
        public int ATT_ID { get; set; }

        [Column("ATT_DESCRIPCION")]
        //[StringLength(2000)]
        public string ATT_DESCRIPCION { get; set; }

        [Column("ATT_ORDEN")]
        //[StringLength(1000)]
        public int ATT_ORDEN { get; set; }

      

        

        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
