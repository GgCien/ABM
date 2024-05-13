using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ABM_TP2.Clases
{
    internal class Usuarios
    {
        public int CodUsusario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Correo { get; set; }
        public PasswordBox Contraseña { get; set; }
    }
}
