using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM_TP1.Clases
{
    internal class Alumnos
    {
        public int ID { get; set; }
        public int DNI { get; set; }
        public string Nom {  get; set; }
        public string Ape { get; set; }
        public DateTime FA { get; set; }
        public DateTime FN { get; set; }
        public int Carrera {  get; set; }
        public int Estado { get; set; }
    }
}
