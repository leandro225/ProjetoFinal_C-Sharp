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

       

        public static void SalvarNovoSabor(Pizza novo)
        {

            PizzaList.Add(novo);

        }

        public static List<Pizza> retornaSabores()
        {
            return PizzaList;
        }

    }
}
