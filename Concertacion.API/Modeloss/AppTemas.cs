using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppTemas
    {
        public AppTemas()
        {
            AppTemasProyectos = new HashSet<AppTemasProyectos>();
        }

        public int TemId { get; set; }
        public string Descripcion { get; set; }
        public decimal LinId { get; set; }
        public DateTime? FecModifico { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }

        public virtual AppLineas Lin { get; set; }
        public virtual ICollection<AppTemasProyectos> AppTemasProyectos { get; set; }
    }
}
