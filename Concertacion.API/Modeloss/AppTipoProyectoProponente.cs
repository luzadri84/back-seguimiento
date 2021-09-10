using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppTipoProyectoProponente
    {
        public int TppId { get; set; }
        public string TppNit { get; set; }
        public decimal TppTipId { get; set; }
        public decimal TppValor { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual BasTiposProyectos TppTip { get; set; }
    }
}
