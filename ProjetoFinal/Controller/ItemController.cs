using Modelos;
using Modelos.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ItemController
    {
       public static void salvarItem(Item novoItem)
       {
            Contexto ctx = new Contexto();
            ctx.Items.Add(novoItem);
            ctx.SaveChanges();
        }
      
       public static Item retornaItem(int id)
        {
            Contexto ctx = new Contexto();

            return ctx.Items.Find(id);
        }

    }
}
