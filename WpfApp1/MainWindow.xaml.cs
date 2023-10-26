using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Order_Class;
using Config_Class;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Order> orders;

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                ConfigLoader loader = new ConfigLoader("C:\\Users\\itige\\source\\repos\\WpfApp1\\WpfApp1\\config.json");
                DevicesConfig config = loader.LoadConfig();

                if (config.Types == null)
                {
                    MessageBox.Show("Не удалоcь спарсить типы устройств. Проверьте файл config.json");
                    Close();
                }
                else if (config.Brands == null)
                {
                    MessageBox.Show("Не удалоcь спарсить производителей устройств. Проверьте файл config.json");
                    Close();
                }

                comboBoxDeviceType.ItemsSource = config.Types;
                comboBoxDeviceBrand.ItemsSource = config.Brands;

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Не удалось найти файл конфигурации!");
                Close();
            }

            orders = new ObservableCollection<Order>();
            DataGridOrders.ItemsSource = orders;

        }

        private void AddOrder_Button(object sender, RoutedEventArgs e)
        {
            bool priority = !(bool)rb1.IsChecked;
            try
            {
                Order order = new Order(comboBoxDeviceType.Text, comboBoxDeviceBrand.Text, (DateTime)DatePicker.SelectedDate, priority, (float)comboBoxDeviceType.SelectedValue, (float)comboBoxDeviceBrand.SelectedValue);
                orders.Add(order);
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Выберите дату!");
            }
        }

        private void ChangeStatus_Button_Click(object sender, RoutedEventArgs e)
        {
            int rowIndex = DataGridOrders.SelectedIndex;
            orders[rowIndex].Ready = !orders[rowIndex].Ready;
            DataGridOrders.Items.Refresh();
        }
    }
}
