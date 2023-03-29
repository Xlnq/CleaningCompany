using CleaningCompany.CleaningCompany11DataSetTableAdapters;
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

namespace CleaningCompany
{
    public partial class PageUser1 : Page
    {
        servicesTableAdapter services = new servicesTableAdapter();
        public PageUser1()
        {
            InitializeComponent();
            servicesGrid.ItemsSource = services.GetData();
        }
    }
}
