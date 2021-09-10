using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("TIPO_TRAYECTORIA")]
    public partial class TipoTrayectoria
    {
        public TipoTrayectoria()
        {
            //AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            //AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        [Key]
        [Column("TTR_ID", TypeName = "int")]
        public int TTR_ID { get; set; }

        [Column("TTR_NOMBRE")]
        //[StringLength(2000)]
        public string TTR_NOMBRE { get; set; }

        [Column("TTR_ACTIVO")]
        //[StringLength(1000)]
        public int TTR_ACTIVO { get; set; }

      

        

        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
