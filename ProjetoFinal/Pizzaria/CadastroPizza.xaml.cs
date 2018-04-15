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
        public CadastroPizza()
        {
            InitializeComponent();           
            DtGrid.ItemsSource = null;
            DtGrid.ItemsSource = Controller.PizzaController.retornaSabores();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCadSabor_Click(object sender, RoutedEventArgs e)
        {
            if (txtNovoSabor.Text.Equals(""))
            {
                MessageBox.Show("Por favor, Insira a Descrição", "Erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Pizza novoSabor = new Pizza();

                novoSabor.SaborPizza = txtNovoSabor.Text;
                Controller.PizzaController.SalvarNovoSabor(novoSabor);
                DtGrid.Items.Refresh();
                MessageBox.Show("Novo Sabor Cadastrado com sucesso", "Sucesso!", MessageBoxButton.OK);
                txtNovoSabor.Clear();
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            bool resp;
            try
            {
                resp = Controller.PizzaController.ExcluirPizza(int.Parse(DtGrid.SelectedValue.ToString()));

                if (resp.Equals(true))
                {
                    MessageBox.Show("Item Excluído com Sucesso!!!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                    DtGrid.ItemsSource = null;
                    DtGrid.ItemsSource = Controller.PizzaController.retornaSabores();                  
                }            
            }
            catch (Exception)
            {
                MessageBox.Show("Por Favor, Selecione um Item !!!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // CellValue = int.Parse(DtGrid.SelectedValue.ToString());              
                txtEditarItem.Text = Controller.PizzaController.retornaDescricao(int.Parse(DtGrid.SelectedValue.ToString()));
                txtEditarItem.Visibility = Visibility.Visible;
                btnSalvarAlt.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                MessageBox.Show("Por Favor, Selecione um item!!","Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnSalvarAlt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Controller.PizzaController.alterarDados(int.Parse(DtGrid.SelectedValue.ToString()), txtEditarItem.Text);
                DtGrid.Items.Refresh();
                txtEditarItem.Visibility = Visibility.Hidden;
                btnSalvarAlt.Visibility = Visibility.Hidden;
            }
            catch (Exception)
            {
                MessageBox.Show("Por Favor, Selecione um item!!");

            }
            //pega o valor selecionado da grid de acordo com o index 
            // private void DtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            // {
            // DataGrid dataGrid = sender as DataGrid;
            // DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            // DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            // CellValue = int.Parse(((TextBlock)RowColumn.Content).Text);
            // MessageBox.Show(CellValue.ToString());
            // CellValue = int.Parse(DtGrid.SelectedValue.ToString());
            // }
        }
    }
}
