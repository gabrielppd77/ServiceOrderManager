using Microsoft.EntityFrameworkCore;
using ServiceOrderManager.Data;
using ServiceOrderManager.Models;
using ServiceOrderManager.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderManager.Services
{
    public class EquipmentService
    {
        private readonly ServiceOrderManagerContext _context;

        public EquipmentService(ServiceOrderManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Equipment>> FindAllAsync()
        {
            return await _context.Equipment.Include(obj => obj.ServiceOrders).ToListAsync();
        }

        public async Task<Equipment> FindByIdAsync(int id)
        {
            return await _context.Equipment.Include(obj => obj.ServiceOrders).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task InsertAsync(Equipment equipment)
        {
            _context.Add(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipment equipment)
        {
            bool hasAny = await _context.Equipment.AnyAsync(x => x.Id == equipment.Id); // Testando se existe esse ID no BD
            if (!hasAny)
            {
                throw new NotFoundException("Id not Found");
            }
            try
            {
                _context.Update(equipment);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Equipment.FindAsync(id);
                _context.Equipment.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Can't delete seller because has Connections");
            }
        }
    }
}
