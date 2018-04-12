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
        int CellValue;

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

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

            bool resp;
            try
            {

                resp = Controller.ClienteController.ExcluirCliente(CellValue);

                if (resp.Equals(true))
                {
                    MessageBox.Show("Item Excluído com Sucesso!!!", "Sucesso", MessageBoxButton.OK);
                    int selectedIndex = DtGrid.SelectedIndex;
                    DtGrid.Items.RemoveAt(selectedIndex);


                }
                else
                {
                    MessageBox.Show("Por Favor, Selecione um Item !!!", "Erro", MessageBoxButton.OK);

                }
            }
            catch (Exception)
            {


            }



        }
       
        private void DtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // DataGrid dataGrid = sender as DataGrid;
            // DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            // DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            // CellValue = int.Parse(((TextBlock)RowColumn.Content).Text);
            // MessageBox.Show(CellValue.ToString());
            CellValue = int.Parse(DtGrid.SelectedValue.ToString());
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                CellValue = int.Parse(DtGrid.SelectedValue.ToString());
                txtEditarItem.Visibility = Visibility.Visible;
                btnSalvarAlt.Visibility = Visibility.Visible;
                txtEditarItem.Text = Controller.ClienteController.retornaDescricao(CellValue);
            }
            catch (Exception)
            {
                MessageBox.Show("Por Favor, Selecione um item!!");
            }


        }
        private void btnSalvarAlt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.ClienteController.alterarDados(CellValue, txtEditarItem.Text);
                DtGrid.Items.Refresh();
                txtEditarItem.Visibility = Visibility.Hidden;
                btnSalvarAlt.Visibility = Visibility.Hidden;

            }
            catch (Exception)
            {
                MessageBox.Show("Por Favor, Selecione um item!!");

            }

        }
        
    }
}
    
