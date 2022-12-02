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
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public ObservableCollection<Employee> employees;

        private Employee _employee;

        private OfficeEquipmentContext _db;

        public AddEmployeeWindow(OfficeEquipmentContext db)
        {
            InitializeComponent();
            this._db = db;
            EmployeeModel employeeModel = new EmployeeModel(_db);

            employees = employeeModel.GetEmployees();
            EmployeeList.ItemsSource = employees;
        }

        private void btn_AddEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeModel employeeModel = new EmployeeModel(_db);
            employeeModel.AddEmployee(first_name_entry.Text, second_name_entry.Text, Convert.ToInt32(workplace_id_entry.Text));

            employees = employeeModel.GetEmployees();
            EmployeeList.ItemsSource = employees;
        }

        private void EmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _employee = (Employee)EmployeeList.SelectedItem;

            Console.WriteLine(_employee);
        }
    }
}
