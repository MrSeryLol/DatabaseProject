using DbManager;
using DbManager.Entities;
using DbManager.Models;
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

namespace OfficeEquipment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (OfficeEquipmentContext context = new OfficeEquipmentContext())
            {
                EmployeeModel employeeModel = new EmployeeModel(context);
                var e = employeeModel.AddEmployee("Сергей", "Полежаев", 1);
                Category category = new Category()
                {
                    CategoryName = "Компьютеры"
                };
                employeeModel.AddCategoryToEmployee(category, e);
                Console.WriteLine("Получение данных из БД");
                var employees = context.Employees.ToList();
                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.SecondName}");
                    foreach (var c in employee.Categories)
                    {
                        Console.WriteLine($"{c.CategoryName}");
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow w1 = new AddEmployeeWindow();
            w1.Owner = this;
            w1.Show();
        }

    }
}
