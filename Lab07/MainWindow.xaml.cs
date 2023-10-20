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
using Business;
using Entity;

namespace Lab07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime invoiceDate;

            if (DateTime.TryParse(txtDate.Text, out invoiceDate))
            {
                BInvoice bInvoice = new BInvoice();
                List<Invoice> invoices = bInvoice.GetByDate(invoiceDate);
                dataGrid.ItemsSource = invoices;
            }
            else
            {
                MessageBox.Show("Formato de fecha incorrecto");
            }
        }

    }
}
