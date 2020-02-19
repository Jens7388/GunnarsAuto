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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GunnarsAuto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        private ViewModel viewModel;
        private static void LoadTables()
        {
            Repository.GetAllSalesPersons();
            if(Repository.salesPersons.Count != 0)
            {
                MessageBox.Show("Alle salgspersoner hentet!");
            }
            else
            {
                MessageBox.Show("Kunne ikke hente salgspersonerne! Tjek koden og prøv igen");
            }
            Repository.GetAllCars();
            if(Repository.cars.Count != 0)
            {
                MessageBox.Show("Alle biler hentet!");
            }
            else
            {
                MessageBox.Show("Kunne ikke hente bilerne! Tjek koden og prøv igen");
            }
            Repository.GetAllSales();
            if(Repository.sales.Count != 0)
            {
                MessageBox.Show("Alle salg hentet!");
            }
            else
            {
                MessageBox.Show("Kunne ikke hente salgene! Tjek koden og prøv igen");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            LoadTables();

            viewModel = new ViewModel();
            DataContext = viewModel;
        }
        public void SalesPersonSelected(object sender, SelectionChangedEventArgs e)
        {
            SalesPerson salesPerson = dataGridSelectSalesPerson.SelectedItem as SalesPerson;
            viewModel.SelectedSalesPerson = salesPerson;
        }
        public void buttonSelectSalesPerson_Click(object sender, RoutedEventArgs e)
        {
            if(viewModel.SelectedSalesPerson == null)
            {
                MessageBox.Show("Du mangler at vælge en salgsperson!");
            }
            else
            {
                groupBoxSelectSalesPerson.Visibility=Visibility.Hidden;
                groupBoxAddCarOrSale.Visibility = Visibility.Visible;
                columnSalesPerson.Header = $"Velkommen, {viewModel.SelectedSalesPerson.Firstname}";
            }
        }

        public void buttonAddCar_Click(object sender, RoutedEventArgs e)
        {

        }

        public void buttonPutCarOnSale_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}