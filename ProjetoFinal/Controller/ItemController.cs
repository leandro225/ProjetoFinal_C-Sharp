using Modelos;
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

       // public static void salvarItem(Item novoItem)
       // {
         //   int id = ultimoID + 1;
         //   ultimoID = id;
         //   novoItem.ItemID = id;
         //   items.Add(novoItem);
        //}

       

        public static Item retornaItem(int id)
        {
            foreach (var x in items)
            {
                if (id==x.ItemID)
                {
                    return x;
                }
            }
            return null;
        }

        
    }
}
