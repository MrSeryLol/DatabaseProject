using DbManager;
using DbManager.Entities;
using DbManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
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
        private EmployeeModel _employeeModel;

        public AddEmployeeWindow(EmployeeModel employeeModel)
        {
            InitializeComponent();
            _employeeModel = employeeModel;
        }

        private void btn_AddEmployee(object sender, RoutedEventArgs e)
        { 
            if (string.IsNullOrEmpty(first_name_entry.Text) || string.IsNullOrEmpty(second_name_entry.Text) ||
                string.IsNullOrEmpty(workplace_id_entry.Text))
            {
                MessageBox.Show("Заполните обязательные поля!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(workplace_id_entry.Text, out _))
            {
                MessageBox.Show("Поле 'Номер рабочего места' должно быть числом!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Convert.ToInt32(workplace_id_entry.Text) == _employeeModel.
                FindEmployeeByID(Convert.ToInt32(workplace_id_entry.Text))?.WorkplaceId)
            {
                MessageBox.Show("Нельзя добавлять одинаковые рабочие места!!!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(patronymic_entry.Text))
            {
                _employeeModel.AddEmployee(first_name_entry.Text, second_name_entry.Text, Convert.ToInt32(workplace_id_entry.Text));
                return;
            }

            _employeeModel.AddEmployee(first_name_entry.Text, second_name_entry.Text, patronymic_entry.Text, Convert.ToInt32(workplace_id_entry.Text));
            first_name_entry.Text = "";
            second_name_entry.Text = "";
            patronymic_entry.Text = "";
            workplace_id_entry.Text = "";
        }
    }
}
