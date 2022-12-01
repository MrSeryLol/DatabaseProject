using DbManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DbManager.Models
{
    /// <summary>
    /// Модель для работы с сущностью Employee
    /// </summary>
    public class EmployeeModel
    {
        /// <summary>
        /// Контекст, через который происходит работа с сущностью
        /// </summary>
        private readonly OfficeEquipmentContext _context;

        public EmployeeModel(OfficeEquipmentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавление "Сотрудника" при нажатии на кнопку
        /// </summary>
        /// <param name="firstName">Имя сотрудника</param>
        /// <param name="secondName">Фамилия сотрудника</param>
        /// <param name="workplace_id">Номер рабочего места, куда он приписан</param>
        /// <returns></returns>
        public Employee AddEmployee(string firstName, string secondName, int workplace_id)
        {
            Employee employee = new Employee()
            {
                FirstName = firstName,
                SecondName = secondName,
                WorkplaceId = workplace_id
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee AddEmployee(string firstName, string secondName, string patronymic, int workplace_id)
        {
            Employee employee = new Employee()
            {
                FirstName = firstName,
                SecondName = secondName,
                Patronymic = patronymic,
                WorkplaceId = workplace_id
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee AddCategoryToEmployee(Category category, Employee employee)
        {
            if (employee == null)
            {
                Console.WriteLine("Вы не создали сотрудника!");
                return employee;
            }

            employee.Categories.Add(category);
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee FindEmployeeByID(int employeeID)
        {
            var employees = _context.Employees.ToList();

            foreach (var employee in employees)
            {
                if (employee.EmployeeId == employeeID)
                {
                    return employee;
                }
            }

            return null;
        }
    }


}
