using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Clases {
    internal class Persona {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool Soltero { get; set; }
        public DateTime FechaIngreso { get; set; }
        public List<string> Telefonos { get; set; }
        public int EmpresaID { get; set; }
    }
}
