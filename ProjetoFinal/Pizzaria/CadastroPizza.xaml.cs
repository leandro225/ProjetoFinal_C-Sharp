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
        List<Pizza> ListaPizzas = new List<Pizza>();

        public CadastroPizza()
        {
            InitializeComponent();

            ListaPizzas = Controller.PizzaController.retornaSabores();

            foreach (var x in ListaPizzas)
            {
                DtGrid.Items.Add(x);
            }

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
                DtGrid.Items.Add(novoSabor);

                MessageBox.Show("Novo Sabor Cadastrado com sucesso", "Sucesso!", MessageBoxButton.OK);
                txtNovoSabor.Clear();


            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            bool resp;
            try
            {
                int teste = int.Parse(txtId.Text);
                resp= Controller.PizzaController.ExcluirPizza(teste);
                if (resp.Equals(true))
                {
                    MessageBox.Show("Item Excluído com Sucesso!!!", "Sucesso", MessageBoxButton.OK);
                    txtId.Clear();
                    this.Close();
                        
                }
                else
                {
                    MessageBox.Show(" ID não encontrado !!!", "Erro", MessageBoxButton.OK);
                    txtId.Clear();
                }

              
                

            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, Insira o id", "Erro!", MessageBoxButton.OK);

            }

        }

    }
}
