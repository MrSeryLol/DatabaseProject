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
    /// Логика взаимодействия для DeleteHardware.xaml
    /// </summary>
    public partial class DeleteHardware : Window
    {
        //ObservableCollection<Hardware> _hardwares;
        HardwareModel _hardwareModel;
        CategoryModel _categoryModel;
        Hardware hardware;
        OfficeEquipmentContext _db;

        public DeleteHardware(HardwareModel hardwareModel, OfficeEquipmentContext db)
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
                             where category.CategoryName == categoryName && hardware.Status == false
                             select hardware).ToList();

            HardwareList.ItemsSource = hardwares;
        }

        private void btn_DeleteHardware_Click(object sender, RoutedEventArgs e)
        {
            if (HardwareList.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали категорию!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            hardware = (Hardware)HardwareList.SelectedItem;
            //hardware = _hardwareModel.FindHardwareByID(hardware.HardwareId);

            _hardwareModel.RemoveHardware(hardware);

            



            //_hardwareModel.Del
            //Close();
        }
    }
}
