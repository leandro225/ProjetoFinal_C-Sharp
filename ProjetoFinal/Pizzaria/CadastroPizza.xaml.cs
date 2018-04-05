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

            cmbSabores.Items.Add("Frango");
            cmbSabores.Items.Add("Palmito");

        }

        
        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();


        }
        
    }
}
