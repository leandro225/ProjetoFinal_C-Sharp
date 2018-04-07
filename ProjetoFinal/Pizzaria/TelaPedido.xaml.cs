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
        public TelaPedido()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPesquisaTel_Click(object sender, RoutedEventArgs e)
        {
            Cliente Recep = Controller.ClienteController.PesquisaCliPorTel(int.Parse(txtTelefone.Text));
            if (Recep==null)
            {
                MessageBox.Show("Cliente não Cadastrado", "Informação", MessageBoxButton.OK);

                CadastroCliente tela = new CadastroCliente();
                tela.ShowDialog();
            }
        }
    }
}
