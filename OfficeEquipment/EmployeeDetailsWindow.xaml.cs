using DbManager;
using DbManager.Entities;
using DbManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OfficeEquipment
{
    /// <summary>
    /// Логика взаимодействия для EmployeeDetailsWindow.xaml
    /// </summary>
    public partial class EmployeeDetailsWindow : Window
    {
        private Employee _employee;
        private EmployeeModel _employeeModel;
        private CategoryModel _categoryModel;
        private HardwareModel _hardwareModel;
        private OfficeEquipmentContext _db;
        public EmployeeDetailsWindow(Employee employee, EmployeeModel employeeModel, CategoryModel category, HardwareModel hardwareModel, OfficeEquipmentContext db)
        {
            InitializeComponent();
            _employee = employee;
            _employeeModel = employeeModel;
            _categoryModel = category;
            _hardwareModel = hardwareModel;
            _db = db;

            FullNameEmployee.Text = $"{_employee.SecondName}\n{_employee.FirstName}\n{_employee.Patronymic}";
            WorkplaceID.Text = $"{_employee.WorkplaceId}";
        }

        private void Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem comboBoxItem = (ComboBoxItem)Categories.SelectedItem;
            string categoryName = comboBoxItem.Content.ToString();
            
            var hardwares = _db.Hardwares
                .FromSql($"SELECT *\r\nFROM employee\r\nJOIN employee_category USING(employee_id)\r\nJOIN category USING(category_id)\r\nJOIN hardware USING(category_id) WHERE category_name = {categoryName} AND employee_id = {_employee.WorkplaceId}")
                .ToList();

            HardwareList.ItemsSource = hardwares;

            foreach (var hardware in hardwares)
            {
                Console.WriteLine(hardware);
            }

            //var price_hardwares = _db.Hardwares
              //  .FromSql($"SELECT SUM(price)\r\nFROM employee\r\nJOIN employee_category USING(employee_id)\r\nJOIN category USING(category_id)\r\nJOIN hardware USING(category_id)\r\nWHERE category_name = {categoryName} AND employee_id = {_employee.WorkplaceId}")
              //.ToList();
        }
    }
}
