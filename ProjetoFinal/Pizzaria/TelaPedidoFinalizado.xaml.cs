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
    /// Interaction logic for TelaPedidoFinalizado.xaml
    /// </summary>
    public partial class TelaPedidoFinalizado : Window
    {
        public TelaPedidoFinalizado()
        {
            InitializeComponent();

            Pedido recebePedido = new Pedido();

            recebePedido = Controller.PedidoController.retornaPedido();

            txtNome.Text = recebePedido.Cliente.Nome;
            txtTelefone.Text = recebePedido.Cliente.Telefone.ToString();
            txtEndereco.Text = recebePedido.Cliente.Endereco;
            txtNumero.Text = recebePedido.Cliente.Numero.ToString();
            txtBairro.Text = recebePedido.Cliente.Bairro;
            txtTotal.Text = recebePedido.Total.ToString();
            txtCodigo.Text = recebePedido.PedidoID.ToString();
            listFinal.ItemsSource = recebePedido.ListaItens;

        }

     

        private void btnFechar_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
