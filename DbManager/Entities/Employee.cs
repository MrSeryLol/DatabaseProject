using System;
using System.Collections.Generic;

namespace DbManager.Entities;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int WorkplaceId { get; set; }

    public virtual ICollection<Category> Categories { get; } = new List<Category>();

    //public Employee(string firstName, string secondName, int workplace_id)
    //{
    //    FirstName = firstName;
    //    SecondName = secondName;
    //    WorkplaceId = workplace_id;
    //}

    //public Employee(string firstName, string secondName, string patronymic, int workplace_id)
    //{
    //    FirstName = firstName;
    //    SecondName = secondName;
    //    Patronymic = patronymic;
    //    WorkplaceId = workplace_id;
    //}
}
