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
        //public static List<Cliente> Clientes = new List<Cliente>();


        public static void SalvarCliente(Cliente novoCli)
        {
            //Clientes.Add(novoCli);
            Contexto ctx = new Contexto();
            ctx.Clientes.Add(novoCli);
            ctx.SaveChanges();
        }
        //public static Cliente PesquisaCliPorTel(int tel)
       // {
           // Contexto ctx = new Contexto();
           // return ctx.Clientes.Find(tel);
       // }


            public static Cliente PesquisaCliPorTel(int tel)
        {
            Contexto ctxx = new Contexto();

            var c = from x in ctxx.Clientes
                    where x.Nome.ToLower().Contains(nome)
                    select x;
            if (c != null)
                return c.FirstorDefault();
            else
                return null;


            foreach (var x in Clientes)
            {
                if (x.Telefone == tel)
                {
                    return x;
                }
            }
            return null;
        }
        public static string retornaDescricao(int telefone)
        {
            foreach (var item in Clientes)
            {
                if (telefone == item.Telefone)
                {
                    return item.Nome;
                }
            }
            return null;
        }
        public static void alterarDados(int telefone, string novaDesc)
        {
            foreach (var x in Clientes)
            {
                if (x.Telefone == telefone)
                {
                    x.Nome = novaDesc;
                }
            }
        }
        public static List<Cliente> retornaClientes()
        {
            return Clientes;
        }
        public static bool ExcluirCliente(int telefone)
        {
            foreach (var cliente in new List<Cliente>(Clientes))
            {
                if (cliente.Telefone == telefone)
                {
                    
                    Clientes.Remove(cliente);
                    return true;
                }

            }
            return false;
        }


        // exemplo  public Cliente PesquisarId(int Cliente)
        //{
        //Contexto ctx = new Contexto();
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
