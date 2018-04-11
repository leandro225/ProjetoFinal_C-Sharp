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
        List<Pizza> ListaPizzas = new List<Pizza>();

        int CellValue;

        public CadastroPizza()
        {
            InitializeComponent();


            ListaPizzas = Controller.PizzaController.retornaSabores();

            foreach (var x in ListaPizzas)
            {
                DtGrid.Items.Add(x);
            }

        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btnCadSabor_Click(object sender, RoutedEventArgs e)
        {
            if (txtNovoSabor.Text.Equals(""))
            {
                MessageBox.Show("Por favor, Insira a Descrição", "Erro!", MessageBoxButton.OK);
            }
            else
            {
                Pizza novoSabor = new Pizza();

                novoSabor.SaborPizza = txtNovoSabor.Text;
                Controller.PizzaController.SalvarNovoSabor(novoSabor);
                DtGrid.Items.Add(novoSabor);

                MessageBox.Show("Novo Sabor Cadastrado com sucesso", "Sucesso!", MessageBoxButton.OK);
                txtNovoSabor.Clear();


            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            bool resp;
            try
            {

                resp = Controller.PizzaController.ExcluirPizza(CellValue);

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
        //pega o valor selecionado da grid de acordo com o index 
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

            CellValue = int.Parse(DtGrid.SelectedValue.ToString());
            txtEditarItem.Visibility = Visibility.Visible;
            btnSalvarAlt.Visibility = Visibility.Visible;
            txtEditarItem.Text = Controller.PizzaController.retornaDescricao(CellValue);



        }

        private void btnSalvarAlt_Click(object sender, RoutedEventArgs e)
        {
            Controller.PizzaController.alterarDados(CellValue, txtEditarItem.Text);

            List<Pizza> ListaPizzasnew = new List<Pizza>();
            ListaPizzasnew = Controller.PizzaController.retornaSabores();

            foreach (var x in ListaPizzasnew)
            {
                DtGrid.Items.Add(x);
            }




            txtEditarItem.Visibility = Visibility.Hidden;
            btnSalvarAlt.Visibility = Visibility.Hidden;
        }
    }
}
