using System.Windows;
using CleaningCompany.CleaningCompany11DataSetTableAdapters;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new PageLogin();
        }
    }
}
