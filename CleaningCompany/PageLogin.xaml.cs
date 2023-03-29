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
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        usersTableAdapter user = new usersTableAdapter();
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            var allLogins = user.GetData().Rows;

            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString() == LoginTxt.Text && allLogins[i][2].ToString() == PasswordTxt.Password)
                {
                    int role = (int)allLogins[i][3];

                    switch (role)
                    {
                        case 1:
                            LoginPage.Content = new Vibor();
                            TextLogin.Visibility = Visibility.Hidden;
                            LoginTxt.Visibility = Visibility.Hidden;
                            TextPassword.Visibility = Visibility.Hidden;
                            PasswordTxt.Visibility = Visibility.Hidden;
                            Log.Visibility = Visibility.Hidden;
                            break;
                        case 2:
                            LoginPage.Content = new PageUser1();
                            TextLogin.Visibility = Visibility.Hidden;
                            LoginTxt.Visibility = Visibility.Hidden;
                            TextPassword.Visibility = Visibility.Hidden;
                            PasswordTxt.Visibility = Visibility.Hidden;
                            Log.Visibility = Visibility.Hidden;
                            break;
                        case 3:
                            LoginPage.Content = new ViborKassir();
                            TextLogin.Visibility = Visibility.Hidden;
                            LoginTxt.Visibility = Visibility.Hidden;
                            TextPassword.Visibility = Visibility.Hidden;
                            PasswordTxt.Visibility = Visibility.Hidden;
                            Log.Visibility = Visibility.Hidden;
                            break;
                    }
                }
            }
        }
    }
}
