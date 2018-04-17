using Modelos;
using Modelos.DAL;
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
        static int ultimoID = 0;
        public static Cliente clienteSelecionado = new Cliente();

        public static void SalvarCliente(Cliente novoCli)
        {

            int id = ultimoID + 1;
            ultimoID = id;
            novoCli.ClienteID = id;
            Clientes.Add(novoCli);

            //Contexto ctx = new Contexto();
           // ctx.Clientes.Add(novoCli);
           // ctx.SaveChanges();
        }
        //public static Cliente PesquisaCliPorTel(int tel)
        // {
        // Contexto ctx = new Contexto();
        // return ctx.Clientes.Find(tel);
        // }


        public static Cliente PesquisaCliPorTel(int tel)
        {
         //   Contexto ctxx = new Contexto();

          //  var c = from x in ctxx.Clientes
          //          where x.Nome.ToLower().Contains(nome)
            //        select x;
         //   if (c != null)
           //     return c.FirstorDefault();
           // else
            //    return null;


            foreach (var x in Clientes)
            {
                if (x.Telefone == tel)
                {
                    return x;
                }
            }
            return null;
        }
        public static void SalvaUltimoCliente(int id)
        {
            foreach (var item in Clientes)
            {
                if (id == item.ClienteID)
                {
                    clienteSelecionado = item;
                }
            }
        
        }
        public static void alterarDados(Cliente cli)
        {
            foreach (var x in Clientes)
            {
                if (x.ClienteID == cli.ClienteID)
                {
                    
                    x.Nome = cli.Nome;
                    x.Endereco = cli.Endereco;
                    x.Numero = cli.Numero;
                    x.Telefone = cli.Telefone;
                    x.Bairro = cli.Bairro;

                    


                }
                
            }
            
        }
        public static List<Cliente> retornaClientes()
        {
            return Clientes;
        }
        public static bool ExcluirCliente(int id)
        {
            foreach (var cliente in new List<Cliente>(Clientes))
            {
                if (cliente.ClienteID == id)
                {

                    Clientes.Remove(cliente);
                    return true;
                }

            }
            return false;
        }


        // exemplo  public Cliente PesquisarId(int Cliente)
        //{
        // Contexto ctx = new Contexto();
        // return ctx.Clientes.Find(idCliente);
        //}

        //exemplo retorna listar public List<Cliente>ListarClientes()
        //{
        //   Contexto ctx = new Contexto();
        // return ctx.Clientes.ToList();
        //}

        ///excluir public static bool ExcluirClientes(int telefone)
        /// {
        //  Contexto ctx = new Contexto();
        //  Cliente c = ctx.Clientes.Find(telefone);

        //  ctx.Entry(c).State = System.Data.Entity.EntityState.Deleted;
        //  ctx.SaveChanges();
        //  return true;
        // }
    }
}
