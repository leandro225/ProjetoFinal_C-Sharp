using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PizzaController
    {

        public static List<Pizza> PizzaList = new List<Pizza>();
        static int ultimoID = 0;
       

        public static void SalvarNovoSabor(Pizza novo)
        {
            int id = ultimoID + 1;
            ultimoID = id;

            novo.IdPizza = id;
            PizzaList.Add(novo);

        }

        public static List<Pizza> retornaSabores()
        {
            return PizzaList;
        }

        public static void ExcluirPizza(int idPizza)
        {
            foreach (var pizza in new List<Pizza>(PizzaList))
            {
                if (pizza.IdPizza==idPizza)
                {
                    ultimoID -= ultimoID;
                    PizzaList.Remove(pizza);
                }
            }
        }


    }
}
