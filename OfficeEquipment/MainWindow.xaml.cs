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

        public ObservableCollection<Employee> _employees;

        private OfficeEquipmentContext _db;
        public MainWindow()
        {
            InitializeComponent();
            //Инициализируем общий контекст для всех окон
            _db = new OfficeEquipmentContext();
            _employeeModel = new EmployeeModel(_db);

            _employees = _employeeModel.GetEmployees();
            EmployeeList.ItemsSource = _employees;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow w1 = new AddEmployeeWindow(_db,_employeeModel);
            w1.Owner = this;
            w1.Show();
        }

        private void EmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             Employee employees = (Employee)EmployeeList.SelectedItem;

            Console.WriteLine(employees);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _employees = _employeeModel.GetEmployees();
            EmployeeList.ItemsSource = _employees;
        }
    }
}
