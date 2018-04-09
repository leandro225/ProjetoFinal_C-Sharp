using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PedidoController
    {
        static int UltimoTelefone;

        //Armazena o telefone que foi previamente digitado na pesquisa
        public static void GuardaTelefone(int telefone)
        {
            UltimoTelefone = telefone;
        }
        //Retorna o telefone digitado no campo de pesquisa
        public static string RetornaTelefone()
        {
            return UltimoTelefone.ToString();

        }


    }
}
