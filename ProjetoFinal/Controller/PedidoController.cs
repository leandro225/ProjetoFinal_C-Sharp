using Modelos;
using Modelos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PedidoController
    {
        public static int UltimoTelefone = 0;
       // static int ultimoID = 0;
       // public static List<Pedido> pedidos = new List<Pedido>();
        public static Pedido ultimoPedido = new Pedido();
       

        public static void SalvarPedido(Pedido novoPedido)
        {
            //ultimoPedido = novoPedido; //guarda as informações do último pedido realizado para ser usado na tela de Pedido Finalizado
            //int id = ultimoID + 1;
            //ultimoID = id;
            //novoPedido.PedidoID = ultimoID;
            //pedidos.Add(novoPedido);

           Contexto ctx = new Contexto();
           ctx.Pedidos.Add(novoPedido);
           ctx.SaveChanges();
        }

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
