using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GunnarsAuto
{
    public class ViewModel
    {
        private Repository repository;

        public ViewModel()
        {
            repository = new Repository();
            List<SalesPerson> salesPersons = Repository.GetAllSalesPersons();
            SalesPersons = new ObservableCollection<SalesPerson>(salesPersons);
        }

        public ObservableCollection<SalesPerson> SalesPersons { get; set; }

        public SalesPerson SelectedSalesPerson { get; set; }
    }
}
