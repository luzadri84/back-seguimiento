using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("CUENTAUSUARIO", Schema = "Seguridad")]
    public partial class Cuentausuario
    {
        public Cuentausuario()
        {
            AppUsuariosImpresion = new HashSet<AppUsuariosImpresion>();
            PerfilesCuentausuario = new HashSet<PerfilesCuentausuario>();
            PreguntaUsuario = new HashSet<PreguntaUsuario>();
        }

        [Key]
        [Column("CUENTAUSUARIOID")]
        public int Cuentausuarioid { get; set; }

        [Column("PERSONAID", TypeName = "numeric(18, 0)")]
        public decimal? Personaid { get; set; }
        [Required]
        [Column("CUENTAUSUARIOUSUARIO")]
        [StringLength(50)]
        public string Cuentausuariousuario { get; set; }
        [Column("CUENTAUSUARIODOMINIO")]
        public bool Cuentausuariodominio { get; set; }
        [Required]
        [Column("CUENTAUSUARIOCLAVE")]
        [StringLength(200)]
        public string Cuentausuarioclave { get; set; }
        [Required]
        [Column("CUENTAUSUARIOEMAIL")]
        [StringLength(50)]
        public string Cuentausuarioemail { get; set; }
        [Column("CUENTAUSUARIOFECHAACTUALIZACIONCLAVE", TypeName = "datetime")]
        public DateTime? Cuentausuariofechaactualizacionclave { get; set; }
        [Column("CUENTAUSUARIONUMEROINTENTOS")]
        public int Cuentausuarionumerointentos { get; set; }
        [Column("CUENTAUSUARIOHISTORIALCLAVE")]
        public string Cuentausuariohistorialclave { get; set; }
        [Column("CUENTAUSUARIOVENCIMIENTO", TypeName = "datetime")]
        public DateTime? Cuentausuariovencimiento { get; set; }
        [Column("CUENTAUSUARIOPLAZOPRIMERLOGEO", TypeName = "datetime")]
        public DateTime? Cuentausuarioplazoprimerlogeo { get; set; }
        [Column("CUENTAUSUARIOSESIONID")]
        [StringLength(40)]
        public string Cuentausuariosesionid { get; set; }
        [Column("CUENTAUSUARIOHABILITADA")]
        public bool Cuentausuariohabilitada { get; set; }
        [Column("CUENTAUSUARIOLINK")]
        [StringLength(50)]
        public string Cuentausuariolink { get; set; }

        [InverseProperty("Cuentausuario")]
        public virtual ICollection<AppUsuariosImpresion> AppUsuariosImpresion { get; set; }
        [InverseProperty("Cuentausuario")]
        public virtual ICollection<PerfilesCuentausuario> PerfilesCuentausuario { get; set; }
        [InverseProperty("Cuentausuario")]
        public virtual ICollection<PreguntaUsuario> PreguntaUsuario { get; set; }
    }
}
