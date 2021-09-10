using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("SERVICIO", Schema = "Seguridad")]
    public partial class Servicio
    {
        public Servicio()
        {
            ServiciosPerfil = new HashSet<ServiciosPerfil>();
        }

        [Key]
        [Column("SERVICIOID")]
        public byte Servicioid { get; set; }
        public byte IdPadre { get; set; }
        [Required]
        [Column("SERVICIOVISTA")]
        [StringLength(250)]
        public string Serviciovista { get; set; }
        [Required]
        [Column("SERVICIONOMBRE")]
        [StringLength(100)]
        public string Servicionombre { get; set; }
        public string Jerarquia { get; set; }
        [Required]
        [Column("SERVICIOTIPO")]
        [StringLength(1)]
        public string Serviciotipo { get; set; }
        [Column("SERVICIONIVEL")]
        public int? Servicionivel { get; set; }
        [Column("SERVICIOREFERENCIAREPORTE")]
        public bool Servicioreferenciareporte { get; set; }
        [Column("SERVICIOACTIVO")]
        public bool Servicioactivo { get; set; }
        [Column("SERVICIOHABILITADO")]
        public bool Serviciohabilitado { get; set; }
        [Column("SERVICIOICONO")]
        [StringLength(50)]
        public string Servicioicono { get; set; }

        [InverseProperty("Servicio")]
        public virtual ICollection<ServiciosPerfil> ServiciosPerfil { get; set; }
    }
}
