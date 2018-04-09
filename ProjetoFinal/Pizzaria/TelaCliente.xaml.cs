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
    /// Interaction logic for TelaCliente.xaml
    /// </summary>
    public partial class TelaCliente : Window
    {
        List<Cliente> ClienteLista = new List<Cliente>();

        public TelaCliente()
        {
            InitializeComponent();
            ClienteLista = Controller.ClienteController.retornaClientes();

            foreach (var x in ClienteLista)
            {
                DtGrid.Items.Add(x);
            }

        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
