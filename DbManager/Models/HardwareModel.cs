using DbManager.Entities;
using Microsoft.EntityFrameworkCore;
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

        public Hardware FindHardwareByID(int hardwareID)
        {
            var hardwares = _context.Hardwares.ToList();

            foreach (var hardware in hardwares)
            {
                if (hardware.HardwareId == hardwareID)
                {
                    return hardware;
                }
            }

            return null;
        }

        public void RemoveHardware(Hardware har)
        {

            //hardware = _context.Hardwares.FirstOrDefault()Remove(hardware);
            //_context.Remove(hardware);
            //_context.Hardwares.FromSql($"DELETE FROM hardware\r\nWHERE hardware_id = {h.HardwareId}");
            //var deletedHardware = from hardware in _context.Hardwares

            //_context.Hardwares.ExecuteDelete($"delete from hardware where hardware_id = ");
            //_context.Entry(hardware).State = EntityState.Deleted;
            //_context.Hardwares.Attach(hardware);

            //var h = (from hardware in _context.Hardwares
            //     where hardware.HardwareId == _context.Hardwares);

            var hardware = _context.Hardwares.FirstOrDefault(x => x.HardwareId == 1);
            _context.Hardwares.Remove(hardware);
            _context.SaveChanges();
        }

        public Hardware ChangeStatus(Hardware hardware)
        {
            hardware.Status = false;
            _context.Hardwares.Update(hardware);
            _context.SaveChanges();
            return hardware;
        }

        public ObservableCollection<Hardware> GetHardwares()
        {
            return new ObservableCollection<Hardware>(
                _context.Hardwares.Select(p => p).ToList<Hardware>());
        }

        public ObservableCollection<Hardware> GetBrokenHardwares()
        {
            return new ObservableCollection<Hardware>(
                _context.Hardwares.Select(h => h)
                .Where(h => h.Status == false)
                .ToList<Hardware>());
        }

        //public ObservableCollection<Hardware> GetHardwaresByCategoryName(string categoryName)
        //{
            //return new ObservableCollection<Hardware>(
              //  _context.Categories.Include(h => h.CategoryId)
                //.Where(h => h.CategoryName == categoryName)).ToList();

            //return new ObservableCollection<Hardware>(
            //    _context.Hardwares.Join(_context.Categories,
            //    h => h.CategoryId,
            //    c => c.CategoryId,
            //    (h, c) => new
            //    {
            //        h.HardwareName,
            //        h.
            //    }
            //return new ObservableCollection<Hardware>(
            //    _context.Hardwares.Select(h => h)
            //    .Include(h => h.CategoryId)
            //    .Where(h => h. == categoryName))
        //}
    }
}
