using System;
using System.Collections.Generic;

namespace DbManager.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Hardware> Hardwares { get; } = new List<Hardware>();

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

    public override string ToString()
    {
        return CategoryName;
    }
}
