using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinCultura.Domain.DAL.Models;

namespace MinCultura.Domain.DAL.Models
{
    [Table("PERFILES_CUENTAUSUARIO", Schema = "Seguridad")]
    public partial class PerfilesCuentausuario
    {
        [Key]
        [Column("PERFILES_CUENTAUSUARIOID")]
        public int PerfilesCuentausuarioid { get; set; }
        [Column("PERFILID")]
        public int Perfilid { get; set; }
        [Column("CUENTAUSUARIOID")]
        public int Cuentausuarioid { get; set; }

        [ForeignKey(nameof(Cuentausuarioid))]
        [InverseProperty("PerfilesCuentausuario")]
        public virtual Cuentausuario Cuentausuario { get; set; }
        [ForeignKey(nameof(Perfilid))]
        [InverseProperty("PerfilesCuentausuario")]
        public virtual Perfil Perfil { get; set; }
    }
}
