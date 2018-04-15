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
            novo.PizzaID = id;
            PizzaList.Add(novo);

        }

        public static List<Pizza> retornaSabores()
        {
            return PizzaList;
        }

        public static bool ExcluirPizza(int idPizza)
        {
            foreach (var pizza in PizzaList)
            {
                if (pizza.PizzaID == idPizza)
                {

                    PizzaList.Remove(pizza);
                    return true;
                }

            }
            return false;
        }

        public static string retornaDescricao(int id)
        {
            foreach (var item in PizzaList)
            {
                if (id == item.PizzaID)
                {
                    return item.SaborPizza;
                }
            }
            return null;
        }

        public static void alterarDados(int id, string novaDesc)
        {
            foreach (var x in PizzaList)
            {
                if (x.PizzaID == id)
                {
                    x.SaborPizza = novaDesc;
                }
            }
        }
    }
}
