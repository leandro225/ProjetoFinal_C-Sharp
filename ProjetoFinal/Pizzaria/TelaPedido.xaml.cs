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
            rbP.IsChecked = true;

            ListaSabores = Controller.PizzaController.retornaSabores();

            foreach (var x in ListaSabores)
            {
                cmbSabores.Items.Add(x.SaborPizza);
                cmbSabores2.Items.Add(x.SaborPizza);
                cmbSabores3.Items.Add(x.SaborPizza);
            }
        }

        //Botão de Fechar a janela
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





        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            Pedido novoPedido = new Pedido();
            Cliente novoCliente = new Cliente();

            try
            {
                novoPedido.Cliente = Controller.ClienteController.PesquisaCliPorTel(int.Parse(blockFone.Text));
                novoPedido.DataPedido = DateTime.Now.ToString();
                novoPedido.PedidoID = 1;

            }
            catch (Exception)
            {


            }

        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            Item novoItem = new Item();

            novoItem.Tamanho = tamanhoSelecionado();//chama método para adicionar o tamanho ao objeto ITEM
            novoItem.Sabor = saborSelecionado();
            novoItem.Adicional = adicionalSelecionado(novoItem);

            ListView1.Items.Add(novoItem);
            // MessageBox.Show(novoItem.Adicional);
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Item Excluído com Sucesso!!!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            int selectedIndex = ListView1.SelectedIndex;
            ListView1.Items.RemoveAt(selectedIndex);
        }


        //Metodos adicionais
        public string tamanhoSelecionado()
        {

            if (rbP.IsChecked == true)
            {
                return rbP.Content.ToString();

            }
            else
            {
                if (rbM.IsChecked == true)
                {
                    return rbM.Content.ToString();
                }
                else
                {
                    return rbG.Content.ToString();
                }
            }

        }

        public string saborSelecionado()
        {
            string sabores;

            if (rbP.IsChecked == true)
            {
                sabores = cmbSabores.SelectedItem.ToString();
                return sabores;
            }
            else
            {
                if (rbM.IsChecked == true)
                {
                    sabores = (cmbSabores.SelectedItem.ToString() + cmbSabores2.SelectedItem.ToString());
                    return sabores;
                }
                else
                {

                    sabores = (cmbSabores.SelectedItem.ToString() + cmbSabores2.SelectedItem.ToString() + cmbSabores3.SelectedItem.ToString());
                    return sabores;
                }
            }
        }

        public string adicionalSelecionado(Item novoItem)
        {
            string adicionais;

            if (cbazeitona.IsChecked == true)
            {
                novoItem.Adicional = "+Azeitona ";

            }
            if (cbBorda.IsChecked == true)
            {
                novoItem.Adicional += "+Borda Recheada ";

            }
            if (cbCheddar.IsChecked == true)
            {
                novoItem.Adicional += "+Cheddar ";

            }
            if (cbBacon.IsChecked == true)
            {
                novoItem.Adicional += "+Bacon ";

            }

            return adicionais = novoItem.Adicional;


        }
    }

}


