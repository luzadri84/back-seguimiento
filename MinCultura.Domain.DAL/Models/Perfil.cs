using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("PERFIL", Schema = "Seguridad")]
    public partial class Perfil
    {
        public Perfil()
        {
            PerfilesCuentausuario = new HashSet<PerfilesCuentausuario>();
            ServiciosPerfil = new HashSet<ServiciosPerfil>();
        }

        [Key]
        [Column("PERFILID")]
        public int Perfilid { get; set; }
        [Required]
        [Column("PERFILNOMBRE")]
        [StringLength(250)]
        public string Perfilnombre { get; set; }
        [Required]
        [Column("PERFILTIPO")]
        [StringLength(1)]
        public string Perfiltipo { get; set; }
        [Column("PERFILHABILITADO")]
        public bool Perfilhabilitado { get; set; }

        [InverseProperty("Perfil")]
        public virtual ICollection<PerfilesCuentausuario> PerfilesCuentausuario { get; set; }
        [InverseProperty("Perfil")]
        public virtual ICollection<ServiciosPerfil> ServiciosPerfil { get; set; }
    }
}
