using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Concertacion.API.Modeloss
{
    public partial class Servicio
    {
        public Servicio()
        {
            ServiciosPerfil = new HashSet<ServiciosPerfil>();
        }

        public byte Servicioid { get; set; }
        public string Serviciovista { get; set; }
        public string Servicionombre { get; set; }
        public HierarchyId Serviciojerarquia { get; set; }
        public string Serviciotipo { get; set; }
        public short? Servicionivel { get; set; }
        public bool Servicioreferenciareporte { get; set; }
        public bool Servicioactivo { get; set; }
        public bool Serviciohabilitado { get; set; }
        public string Servicioicono { get; set; }

        public virtual ICollection<ServiciosPerfil> ServiciosPerfil { get; set; }
    }
}
