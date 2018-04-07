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
    /// Interaction logic for CadastroCliente.xaml
    /// </summary>
    public partial class CadastroCliente : Window
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvarCli_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente novoCli = new Cliente();

                novoCli.Nome = txtNome.Text;
                novoCli.Telefone =int.Parse(txtTelefone.Text);
                novoCli.Endereco = txtEnd.Text;
                novoCli.Numero = int.Parse(txtNumero.Text);
                novoCli.Bairro = txtBairro.Text;

                //Inserir conexão com a controller de cadastrar na lista de clientes

                MessageBox.Show("Cliente cadastrado com sucesso!", "Suecesso");

            }
            catch (Exception)
            {

                MessageBox.Show("! Favor inserir todos os dados corretamente!", "Atenção");
            }
        }
    }
}
