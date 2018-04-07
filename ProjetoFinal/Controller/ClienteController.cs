using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ClienteController
    {
        public static List<Cliente> Clientes = new List<Cliente>();


        public static void SalvarCliente(Cliente novoCli)
        {
            Clientes.Add(novoCli);
        }

        public static Cliente PesquisaCliPorTel(int tel)
        {
            foreach (var x in Clientes)
            {
                if (x.Telefone == tel)
                {
                    return x;
                }
            }
            return null;
        }


    }
}
