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
    /// Interaction logic for TelaPedido.xaml
    /// </summary>
    public partial class TelaPedido : Window
    {
        List<Pizza> ListaSabores = new List<Pizza>();

        public TelaPedido()
        {
            InitializeComponent();

            
            ListaSabores= Controller.PizzaController.retornaSabores();

           foreach (var x in ListaSabores)
            {
                cmbSabores.Items.Add(x.SaborPizza);
                cmbSabores2.Items.Add(x.SaborPizza);
                cmbSabores3.Items.Add(x.SaborPizza);
            }

            
            
            
          
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPesquisaTel_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                Cliente Recep = Controller.ClienteController.PesquisaCliPorTel(int.Parse(txtTelefone.Text));


                if (Recep == null)
                {
                    MessageBox.Show("Cliente não Cadastrado", "Informação", MessageBoxButton.OK);
                    Controller.PedidoController.GuardaTelefone(int.Parse(txtTelefone.Text));
                    CadastroCliente tela = new CadastroCliente();

                    tela.ShowDialog();
                }
                else
                {   
                    // Caso o cliente já esteja cadastrado, as informações aparecerão na tela
                    blockNome.Text = Recep.Nome;
                    blockFone.Text = Recep.Telefone.ToString();
                    blockEnd.Text = Recep.Endereco;
                    blockNr.Text = Recep.Numero.ToString();
                    blockBairro.Text = Recep.Bairro;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por Favor, Insira o Telefone", "Informação", MessageBoxButton.OK);

            }

        }
        //Recebendo o Valor selecionado de uma combobox
        private void cmbSabores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //o TextBlock recebe o valor que foi selecionado na ComboBox
            tbSabor.Text = ((ComboBox)sender).SelectedItem.ToString();

        }

        private void cmbSabores2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            tbSabor2.Text = ((ComboBox)sender).SelectedItem.ToString();
        }

        private void cmbSabores3_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
                tbSabor3.Text = ((ComboBox)sender).SelectedItem.ToString();
            
        }

        private void rbP_Checked(object sender, RoutedEventArgs e)
        {
               

            cmbSabores2.Visibility = Visibility.Hidden;
            cmbSabores3.Visibility = Visibility.Hidden;
            lblSabor2.Visibility = Visibility.Hidden;
            lblSabor3.Visibility = Visibility.Hidden;

        }

        private void rbM_Checked(object sender, RoutedEventArgs e)
        {
           
            // cmbSabores2.IsEnabled = true;
            //cmbSabores3.IsEnabled = false;
            cmbSabores2.Visibility = Visibility.Visible;
            cmbSabores3.Visibility = Visibility.Hidden;
            lblSabor2.Visibility = Visibility.Visible;
            lblSabor3.Visibility = Visibility.Hidden;

        }

        private void rbG_Checked(object sender, RoutedEventArgs e)
        {
            
            //cmbSabores2.IsEnabled = true;
            //cmbSabores3.IsEnabled = true;
            cmbSabores2.Visibility = Visibility.Visible;
            cmbSabores3.Visibility = Visibility.Visible;
            lblSabor2.Visibility = Visibility.Visible;
            lblSabor3.Visibility = Visibility.Visible;

        }

        
    }
}
