using Modelos;
using Modelos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PizzaController
    {

       // public static List<Pizza> PizzaList = new List<Pizza>();
       // static int ultimoID = 0;


        public static void SalvarNovoSabor(Pizza novo)
        {
            //int id = ultimoID + 1;
            // ultimoID = id;
            // novo.PizzaID = id;
            // PizzaList.Add(novo);

            Contexto ctx = new Contexto();
            ctx.Pizzas.Add(novo);
            ctx.SaveChanges();
        }

        public static List<Pizza> retornaSabores()
        {

            Contexto ctx = new Contexto();
            return ctx.Pizzas.ToList();
        }

        public static bool ExcluirPizza(int idpizza)
        {
            Contexto ctx = new Contexto();
            Pizza p = ctx.Pizzas.Find(idpizza);

            ctx.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            ctx.SaveChanges();
            return true;
        }

        public static Pizza retornaDescricao(int id)
        {
            Contexto ctx = new Contexto();
           
            return ctx.Pizzas.Find(id);


            //foreach (var item in pizzalist)
            //{
            //    if (id == item.pizzaid)
            //    {
            //        return item.saborpizza;
            //    }
            //}
            //return null;
        }

        public static void alterarDados(int id, string novaDesc)
        {
            Contexto ctx = new Contexto();
            
            Pizza p = ctx.Pizzas.Find(id);
            p.SaborPizza = novaDesc;
            ctx.SaveChanges();          

            //foreach (var x in PizzaList)
            //{
            //    if (x.PizzaID == id)
            //    {
            //        x.SaborPizza = novaDesc;
            //    }
            //}
        }
    }
}
