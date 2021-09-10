using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("CON_ESTADOS")]
    public partial class ConEstados
    {
        public ConEstados()
        {
            //AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            //AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        [Key]
        [Column("PRO_ESTADO", TypeName = "numeric(18, 0)")]
        public int ProEstado { get; set; }

        [Column("PRO_NOMBRE_ESTADO")]
        //[StringLength(2000)]
        public string ProNombreEstado { get; set; }


        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
