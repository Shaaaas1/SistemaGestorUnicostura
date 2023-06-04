using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicosturaAdminEnC.Clases
{
    public class PedidoMolde
    {
        public int IdPedido { get; set; }
        public int IdEstado { get; set;}
        public int IdRepartidor { get; set;}
        public int IdDistribucion { get; set;}
        public int IdPago { get; set; }
        public int TotalMoldes { get; set; }
        public int ValorPedido { get; set; }
        public int NumBoletaImpresa { get; set; }
        public DateTime Fecha { get; set; }

    }
}
