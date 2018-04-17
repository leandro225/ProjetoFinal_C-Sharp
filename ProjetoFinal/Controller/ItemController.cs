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
        public static List<Item> items = new List<Item>();
       // static int ultimoID = 0;

       public static void salvarItem(Item novoItem)
       {
            Contexto ctx = new Contexto();
            ctx.Items.Add(novoItem);
            ctx.SaveChanges();


            //int id = ultimoID + 1;
            //ultimoID = id;
            // novoItem.ItemID = id;
            //items.Add(novoItem);
        }

       

        public static Item retornaItem(int id)
        {
            Contexto ctx = new Contexto();

            return ctx.Items.Find(id);



            //foreach (var x in items)
            //{
            //    if (id==x.ItemID)
            //    {
            //        return x;
            //    }
            //}
            //return null;
        }


    }
}
