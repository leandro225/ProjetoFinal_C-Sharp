using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pizzaria
{
    /// <summary>
    /// Interaction logic for CadastroPizza.xaml
    /// </summary>
    public partial class CadastroPizza : Window
    {
        

        public CadastroPizza()
        {
            InitializeComponent();


            Pizza pizzahut = new Pizza();

            pizzahut.IdPizza = 1;
            pizzahut.SaborPizza = "Calabresa";


            Dtgrid.Items.Add(pizzahut);

            Pizza pizzahut2 = new Pizza();

            pizzahut2.IdPizza = 2;
            pizzahut2.SaborPizza = "Queijo";
            Dtgrid.Items.Add(pizzahut2);
        }

       

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void btnCadSabor_Click(object sender, RoutedEventArgs e)
        {
            if (txtNovoSabor.Text.Equals(""))
            {
                MessageBox.Show("Por favor, Insira a Descrição", "Erro!", MessageBoxButton.OK);
            }
            else
            {
                Pizza novoSabor = new Pizza();

                novoSabor.SaborPizza = txtNovoSabor.Text;
                Controller.PizzaController.SalvarNovoSabor(novoSabor);
                Dtgrid.Items.Add(novoSabor);
                MessageBox.Show("Novo Sabor Cadastrado com sucesso", "Sucesso!", MessageBoxButton.OK);
                txtNovoSabor.Clear();
            }
        }
    }
}
