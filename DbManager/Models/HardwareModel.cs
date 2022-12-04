using DbManager.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Models
{
    public class HardwareModel
    {
        private readonly OfficeEquipmentContext _context;

        public HardwareModel(OfficeEquipmentContext context)
        {
            _context = context;
        }

        public Hardware AddHardware(string hardware_name, decimal price, DateOnly production_year, DateOnly purchase_date, int category_id)
        {
            Hardware hardware = new Hardware()
            {
                HardwareName = hardware_name,
                Price = price,
                ProductionYear = production_year,
                PurchaseDate = purchase_date,
                CategoryId = category_id
            };

            _context.Hardwares.Add(hardware);
            _context.SaveChanges();
            return hardware;
        }

        public ObservableCollection<Hardware> GetHardwares()
        {
            return new ObservableCollection<Hardware>(
                _context.Hardwares.Select(p => p).ToList<Hardware>());
        }
    }
}
