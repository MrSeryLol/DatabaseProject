using DbManager.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Category> GetCategories()
        {
            return new ObservableCollection<Category>(
                _context.Categories.Select(p => p).ToList<Category>());
        }
    }
}
