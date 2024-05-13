using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM_TP2.Clases
{
    internal class Empleado
    {
        private Usuarios usuaut;

        public Empleado(Usuarios usuaut)
        {
            this.usuaut = usuaut;
        }

        public int Legajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public DateTime Alta { get; set; }
        public int CodCargo { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
    }
}
