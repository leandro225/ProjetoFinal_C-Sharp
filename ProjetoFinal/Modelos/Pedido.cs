using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Pedido
    {
        
             public int IdPedido { get; set; }
             
             public DateTime DataPedido { get; set; }
             public Cliente cliente { get; set;  }
             public List <Pizza> pizza { get; set; }

        



    }
}
