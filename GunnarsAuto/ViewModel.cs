using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GunnarsAuto
{
    public class ViewModel
    {
        public ViewModel()
        {
            List<SalesPerson> salesPersons = Repository.GetAllSalesPersons();
            List<Car> cars = Repository.GetAllCars();
            List<Sale> sales = Repository.GetAllSales();
            SalesPersons = new ObservableCollection<SalesPerson>(salesPersons);
            Cars = new ObservableCollection<Car>(cars);
            Sales = new ObservableCollection<Sale>(sales);
        }
        public ObservableCollection<SalesPerson> SalesPersons { get; set; }
        public ObservableCollection<Car> Cars { get; set; }
        public ObservableCollection<Sale> Sales { get; set; }
        public SalesPerson SelectedSalesPerson { get; set; }
        public Car SelectedCar { get; set; }
        public Sale SelectedSale { get; set; }
    }
}
