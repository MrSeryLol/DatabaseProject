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

        private readonly List<Category> _categories;

        public CategoryModel(OfficeEquipmentContext context)
        {
            _context = context;

            _categories = new List<Category>()
            {
                new Category() { CategoryName = "Компьютеры" },
                new Category() { CategoryName = "Планшеты"},
                new Category() { CategoryName = "Ноутбуки"},
                new Category() { CategoryName = "Мониторы"},
                new Category() { CategoryName = "Мышки"},
                new Category() { CategoryName = "Флешки"},
                new Category() { CategoryName = "Клавиатуры"},
                new Category() { CategoryName = "Принтеры"},
            };

            _context.Categories.AddRange(_categories);
        }

        public Category AddCategory(string categoryName)
        {
            Category category = new Category()
            {
                CategoryName = categoryName,
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category AddHardwareToCatrgory(Hardware hardware, Category category)
        {
            category.Hardwares.Add(hardware);
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }
    }
}
