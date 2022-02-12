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
using System.Windows.Shapes;


namespace BankStorePlus
{
    /// <summary>
    /// Логика взаимодействия для AdminPanelWindow
    /// </summary>
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow()
        {
            InitializeComponent();
        }

        private void Currency_Detectors_Click(object sender, RoutedEventArgs e)
        {
            Currency_Detectors currency_Detectors = new Currency_Detectors();
            currency_Detectors.Show();
            this.Hide();
        }

        private void Bill_Counters_Click(object sender, RoutedEventArgs e)
        {
            Bill_Counters bill_Counters = new Bill_Counters();
            bill_Counters.Show();
            this.Hide();
        }

        private void Сoin_counters_Click(object sender, RoutedEventArgs e)
        {
            Сoin_Сounters сoin_Сounters = new Сoin_Сounters();
            сoin_Сounters.Show();
            this.Hide();
        }

        private void Button_Vehod_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
