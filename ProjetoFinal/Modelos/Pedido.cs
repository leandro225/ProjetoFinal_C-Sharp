using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Pedido
    {
        
        public int PedidoID { get; set; }

        public string DataPedido { get; set; }

        public Cliente Cliente { get; set; }

        public double Total { get; set; }

        public List<Item> ListaItens { get; set; }





    }
}
