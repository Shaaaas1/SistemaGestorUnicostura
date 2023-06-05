using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicosturaAdminEnC.Clases
{
    public class DetallePedidoMoldes
    {
        public int IdDetallePedido { get; set; }
        public int IdPedido { get; set; }
        public int IdTalla { get; set; }
        public int CodigoMolde { get; set; }
        public Boolean MoldeEnStock { get; set; }
        public Boolean MoldeFallido { get; set; }
    }
}
