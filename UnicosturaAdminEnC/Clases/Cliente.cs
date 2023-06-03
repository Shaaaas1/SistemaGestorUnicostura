using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicosturaAdminEnC.Clases
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get;  set; }
        public int CelularCliente { get; set; }
        public string Direccion { get; set; }
        public string Rut { get; set; }
        public string Alias { get; set; }
        public  string Fuente { get; set; }
    }
}
