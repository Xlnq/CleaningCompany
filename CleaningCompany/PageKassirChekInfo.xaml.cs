using CleaningCompany.CleaningCompany11DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;

namespace CleaningCompany
{
    /// <summary>
    /// Логика взаимодействия для PageKassirChekInfo.xaml
    /// </summary>
    public partial class PageKassirChekInfo : Page
    {
        ordersTableAdapter orders = new ordersTableAdapter();
        infordersTableAdapter inforders = new infordersTableAdapter();
        List<Tovar> uslugi = new List<Tovar>();
        int Sum = 0;
        public PageKassirChekInfo()
        {
            InitializeComponent();
            var itom = inforders.GetData().Rows;
            for (int i = 0;i< itom.Count;i++)
            {
                string path = "C:\\Users\\mrpor\\Desktop\\Чек" + (int)itom[i][0];
                if (File.Exists(path))
                {
                    ViborCheka.Items.Add((int)itom[i][0]);
                }
            }
            InfUsl.ItemsSource= uslugi;
        }

        private void ViborCheka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uslugi.Clear();
            var itom = orders.GetData().Rows;
            for (int i = 0; i < itom.Count; i++)
            {
               if ((int)itom[i][1] == (int)ViborCheka.SelectedValue)
               {
                    uslugi.Add(new Tovar { Id = Convert.ToInt32(itom[i][1]),Idservice = Convert.ToInt32(itom[i][2]), Name = itom[i][3].ToString(), Type = Convert.ToInt32(itom[i][4]), Price = Convert.ToInt32(itom[i][5])});
                    
               }
            }
            InfUsl.Items.Refresh();
            foreach(var item in uslugi)
            {
                Sum += item.Price;
            }
            var polz = inforders.GetData().Rows;
            for (int i = 0; i < polz.Count; i++)
            {
                if ((int)polz[i][0] == (int)ViborCheka.SelectedValue)
                {
                    Us.Text = Convert.ToString(polz[i][1]);
                    Dat.Text = Convert.ToString(polz[i][2]);
                    Su.Text = Convert.ToString(Sum);
                }
            }
        }
    }
}
