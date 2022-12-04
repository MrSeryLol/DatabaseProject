using DbManager;
using DbManager.Entities;
using DbManager.Models;
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
using System.Windows.Shapes;

namespace OfficeEquipment
{
    /// <summary>
    /// Логика взаимодействия для ChangeStatusWindow.xaml
    /// </summary>
    public partial class ChangeStatusWindow : Window
    {
        HardwareModel _hardwareModel;
        ObservableCollection<Hardware> _hardwares;
        Hardware hardware;
        OfficeEquipmentContext _db;

        public ChangeStatusWindow(HardwareModel hardwareModel, OfficeEquipmentContext db)
        {
            InitializeComponent();
            _hardwareModel = hardwareModel;
            _db = db;
        }

        private void Categories_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)CategoriesBox.SelectedItem;
            string categoryName = comboBoxItem.Content.ToString();

            var hardwares = (from hardware in _db.Hardwares
                            join category in _db.Categories on hardware.CategoryId equals category.CategoryId
                            where category.CategoryName == categoryName
                            select hardware).ToList();

            HardwareList.ItemsSource = hardwares;
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ChangeHardwareStatus_Click(object sender, RoutedEventArgs e)
        {
            if (HardwareList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали категорию!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            hardware = (Hardware)HardwareList.SelectedItem;

            hardware = _hardwareModel.FindHardwareByID(hardware.HardwareId);
            _hardwareModel.ChangeStatus(hardware);

            _hardwares = _hardwareModel.GetHardwares();
            HardwareList.ItemsSource = _hardwares;
        }
    }
}
