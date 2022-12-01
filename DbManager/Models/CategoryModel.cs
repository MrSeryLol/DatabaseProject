using DbManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Models
{
    public class CategoryModel
    {
        private readonly OfficeEquipmentContext _context;

        public CategoryModel(OfficeEquipmentContext context)
        {
            _context = context;
        }

        public void AddCategory(string categoryName)
        {
            Category category = new Category()
            {
                CategoryName = categoryName,
            };


        }
    }
}
