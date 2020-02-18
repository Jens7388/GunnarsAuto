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
        public MainWindow()
        {
            InitializeComponent();

            Repository.GetAllSalesPersons();
            if(Repository.GetAllSalesPersons().Count != 0)
            {
                MessageBox.Show("Alle salgspersoner hentet!");
            }
            else
            {
                MessageBox.Show("Kunne ikke hente salgspersonerne! Tjek koden og prøv igen");
            }
            Repository.GetAllCars();
            if(Repository.GetAllCars().Count != 0)
            {
                MessageBox.Show("Alle biler hentet!");
            }
            else
            {
                MessageBox.Show("Kunne ikke hente bilerne! Tjek koden og prøv igen");
            }
            Repository.GetAllSales();
            if(Repository.GetAllSales().Count != 0)
            {
                MessageBox.Show("Alle salg hentet!");
            }
            else
            {
                MessageBox.Show("Kunne ikke hente salgene! Tjek koden og prøv igen");
            }
        }
    }
}
