using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("TRAYECTORIA_PROYECTO")]
    public partial class TrayectoriaProyecto
    {
        public TrayectoriaProyecto()
        {
            //AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            //AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        [Key]
        [Column("TPR_ID", TypeName = "int")]
        public int TPR_ID { get; set; }

        [Column("TPR_RESPUESTA_TRAYECTORIA")]
        //[StringLength(2000)]
        public string TPR_RESPUESTA_TRAYECTORIA { get; set; }

        [Column("TRA_ID")]
        //[StringLength(1000)]
        public int TRA_ID { get; set; }

        [Column("PRO_ID", TypeName = "numeric(18, 0)")]
        //[StringLength(1000)]
        public decimal PRO_ID { get; set; }

        //[Column("TTR_ID")]
        ////[StringLength(1000)]
        //public int TTR_ID { get; set; }








        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
