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
    /// Interaction logic for EditarCliente.xaml
    /// </summary>
    public partial class EditarCliente : Window
    {
       public  Cliente exibirCliente = new Cliente();

        public EditarCliente()
        {

            InitializeComponent();

            //recebe dados do ultimo cliente selecionado na lista
            exibirCliente = Controller.ClienteController.clienteSelecionado;

            //recebe os dados do cliente sem alteracoes 
            txtNome.Text = exibirCliente.Nome;
            txtTelefone.Text = exibirCliente.Telefone.ToString();
            txtEnd.Text = exibirCliente.Endereco;
            txtNumero.Text = exibirCliente.Numero.ToString();
            txtBairro.Text = exibirCliente.Bairro;

            

           
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSalvarAlt_Click(object sender, RoutedEventArgs e)
        {
            //recebe os dados de todos os campos
            exibirCliente.Nome = txtNome.Text.ToString();
            exibirCliente.Telefone = int.Parse(txtTelefone.Text);
            exibirCliente.Endereco = txtEnd.Text.ToString();
            exibirCliente.Numero = int.Parse(txtNumero.Text);
            exibirCliente.Bairro = txtBairro.Text.ToString();

            // envia para controller as alteracos 
            Controller.ClienteController.alterarDados(exibirCliente);

            MessageBox.Show("Alterações Feitas Com Sucesso!!!");

            this.Close();

        }
    }
}
