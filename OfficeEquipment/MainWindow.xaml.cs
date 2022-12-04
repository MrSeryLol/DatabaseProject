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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OfficeEquipment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeModel _employeeModel;

        private Employee _employee;

        private CategoryModel _categoryModel;

        private HardwareModel _hardwareModel;

        public ObservableCollection<Employee> _employees;

        private OfficeEquipmentContext _db;
        public MainWindow()
        {
            InitializeComponent();
            //Инициализируем общий контекст для всех окон
            _db = new OfficeEquipmentContext();
            _employeeModel = new EmployeeModel(_db);
            _categoryModel = new CategoryModel(_db);
            _hardwareModel = new HardwareModel(_db);

            _employees = _employeeModel.GetEmployees();
            EmployeeList.ItemsSource = _employees;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow w1 = new AddEmployeeWindow(_employeeModel);
            w1.Owner = this;
            w1.Show();
        }

        private void EmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _employee = (Employee)EmployeeList.SelectedItem;

            Console.WriteLine(_employee);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _employees = _employeeModel.GetEmployees();
            EmployeeList.ItemsSource = _employees;
        }

        private void MenuItem_ExtraInfoClick(object sender, RoutedEventArgs e)
        {
            EmployeeDetailsWindow employeeDetailsWindow = new EmployeeDetailsWindow(_employee, _employeeModel, _categoryModel, _hardwareModel, _db);
            employeeDetailsWindow.Owner = this;
            employeeDetailsWindow.Show();
        }

        private void AddTech_Click(object sender, RoutedEventArgs e)
        {
            AddHardwareWindow w2 = new AddHardwareWindow(_categoryModel, _employeeModel, _hardwareModel, _employees);
            w2.Owner = this;
            w2.Show();
        }
       
        private void DeleteHardware_Click(object sender, RoutedEventArgs e)
        {
            DeleteHardware deleteHardware = new DeleteHardware(_hardwareModel, _db);
            deleteHardware.Owner = this;
            deleteHardware.Show();
        }

        private void ChangeHardwareStatus_Click(object sender, RoutedEventArgs e)
        {
            ChangeStatusWindow changeStatusWindow = new ChangeStatusWindow(_hardwareModel, _db);
            changeStatusWindow.Owner = this;
            changeStatusWindow.Show();
        }
    }
}
