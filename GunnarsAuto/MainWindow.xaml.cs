﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private const string connectionString = @"
            Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=GunnarsAutoDB;
            Integrated Security = True;         
            ";
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
        public void SalesPersonSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SalesPerson salesPerson = comboBoxSelectSalesPerson.SelectedItem as SalesPerson;
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
                groupBoxSelectSalesPerson.Visibility = Visibility.Hidden;
                groupBoxCars.Visibility = Visibility.Visible;
                groupBoxAddNewCar.Visibility = Visibility.Visible;
                textBlockSalesPerson.Text = $"Velkommen, {viewModel.SelectedSalesPerson.Firstname}";
            }
        }
        public void buttonAddCar_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxCarChassisNumber.Text == null || textBoxCarMake.Text == null || textBoxCarModel.Text == null ||
                textBoxCarRegistrationNumber.Text == null || ComboboxCarStatus.SelectedItem == null)
            {
                MessageBox.Show("Du mangler at udfylde et felt!");
            }
            else
            {
                Car car = new Car(textBoxCarMake.Text, textBoxCarModel.Text,
                    textBoxCarChassisNumber.Text, textBoxCarRegistrationNumber.Text, ComboboxCarStatus.Text);

                string sql = $"INSERT INTO Car VALUES('{car.Make}', '{car.Model}', " +
                   $"'{car.ChassisNumber}', '{car.RegistrationNumber}', '{car.CarType}')";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                command.Dispose();
                viewModel.Cars.Add(car);
            }
        }

        public void buttonPutCarOnSale_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CarSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car car = dataGridSelectedCar.SelectedItem as Car;
            viewModel.SelectedCar = car;
        }
    }
}