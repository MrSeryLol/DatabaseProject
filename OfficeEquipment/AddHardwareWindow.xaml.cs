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
    /// Логика взаимодействия для AddHardwareWindow.xaml
    /// </summary>
    public partial class AddHardwareWindow : Window
    {
        private readonly CategoryModel _categoryModel;
        private readonly EmployeeModel _employeeModel;
        private readonly HardwareModel _hardwareModel;
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Category> _categories;

        public AddHardwareWindow(CategoryModel categoryModel, EmployeeModel employeeModel, HardwareModel hardwareModel, ObservableCollection<Employee> employees)
        {
            InitializeComponent();
            _categoryModel = categoryModel;
            _employeeModel = employeeModel;
            _hardwareModel = hardwareModel;
            _employees = employees;
        }

        private void Employee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_employees = _employeeModel.GetEmployees();
            //Employee.ItemsSource = _employees;
        }

        private void Employee_DropDownOpened(object sender, EventArgs e)
        {
            _employees = _employeeModel.GetEmployees();
            Employee.ItemsSource = _employees;
        }

        private void Categories_DropDownOpened(object sender, EventArgs e)
        {
            _categories = _categoryModel.GetCategories();
        }

        private void btn_AddHardware(object sender, EventArgs e)
        {
            Employee employee = (Employee)Employee.SelectedItem;
            ComboBoxItem comboBoxItem =(ComboBoxItem) CategoriesBox.SelectedItem;
            string categoryName = comboBoxItem.Content.ToString();
            
            Category category = _categoryModel.AddCategory(categoryName);
            _employeeModel.AddCategoryToEmployee(category, employee);
            _hardwareModel.AddHardware(hardware_name.Text, Convert.ToDecimal(price.Text), DateOnly.Parse(production_year.Text), DateOnly.Parse(purchase_date.Text), category.CategoryId);
            hardware_name.Text = "";
            price.Text = "";
            production_year.Text = "";
            purchase_date.Text = "";
        }

    }
}
