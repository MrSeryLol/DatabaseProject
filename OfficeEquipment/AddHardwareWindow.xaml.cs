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
using System.Windows.Shapes;

namespace OfficeEquipment
{
    /// <summary>
    /// Логика взаимодействия для AddHardwareWindow.xaml
    /// </summary>
    public partial class AddHardwareWindow : Window
    {
        private readonly Employee _employee;
        private readonly EmployeeModel _employeeModel;

        public AddHardwareWindow(Employee employee, EmployeeModel employeeModel)
        {
            InitializeComponent();
            _employee = employee;
            _employeeModel = employeeModel;

        }
    }
}
