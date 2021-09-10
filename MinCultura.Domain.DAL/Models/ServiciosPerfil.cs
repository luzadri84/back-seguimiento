using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("SERVICIOS_PERFIL", Schema = "Seguridad")]
    public partial class ServiciosPerfil
    {
        [Key]
        [Column("SERVICIOS_PERFILID")]
        public int ServiciosPerfilid { get; set; }
        [Column("SERVICIOID")]
        public byte Servicioid { get; set; }
        [Column("PERFILID")]
        public int Perfilid { get; set; }

        [ForeignKey(nameof(Perfilid))]
        [InverseProperty("ServiciosPerfil")]
        public virtual Perfil Perfil { get; set; }
        [ForeignKey(nameof(Servicioid))]
        [InverseProperty("ServiciosPerfil")]
        public virtual Servicio Servicio { get; set; }
    }
}
