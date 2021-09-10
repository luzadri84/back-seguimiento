using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppVigencias
    {
        public AppVigencias()
        {
            AppAreas = new HashSet<AppAreas>();
            AppCausalesRechazo = new HashSet<AppCausalesRechazo>();
            AppRadicadoProyectos = new HashSet<AppRadicadoProyectos>();
            AppRequisitos = new HashSet<AppRequisitos>();
            AppTipoEntidadUsuario = new HashSet<AppTipoEntidadUsuario>();
            AppTiposPuntaje = new HashSet<AppTiposPuntaje>();
            BasTiposProyectos = new HashSet<BasTiposProyectos>();
            Trayectoria = new HashSet<Trayectoria>();
        }

        public decimal VigId { get; set; }
        public string VigNombre { get; set; }
        public DateTime VigFechaInicio { get; set; }
        public DateTime VigFechaFinal { get; set; }
        public string VigEstado { get; set; }
        public int? VigPlazoDocumentacion { get; set; }
        public int? VigDiasExpiracionProyecto { get; set; }
        public int? VigConsecutivo { get; set; }
        public int? VigValorMaximo { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
        public int VigConsecutivoNac { get; set; }

        public virtual ICollection<AppAreas> AppAreas { get; set; }
        public virtual ICollection<AppCausalesRechazo> AppCausalesRechazo { get; set; }
        public virtual ICollection<AppRadicadoProyectos> AppRadicadoProyectos { get; set; }
        public virtual ICollection<AppRequisitos> AppRequisitos { get; set; }
        public virtual ICollection<AppTipoEntidadUsuario> AppTipoEntidadUsuario { get; set; }
        public virtual ICollection<AppTiposPuntaje> AppTiposPuntaje { get; set; }
        public virtual ICollection<BasTiposProyectos> BasTiposProyectos { get; set; }
        public virtual ICollection<Trayectoria> Trayectoria { get; set; }
    }
}
