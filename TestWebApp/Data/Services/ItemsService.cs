using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Data.Services
{
    public class ItemsService : IItemsService
    {
        private readonly ApplicationDbContext _context;

        public ItemsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }
 
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var result = await _context.Items.ToListAsync();

            return result;
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            var result = await _context.Items.FirstOrDefaultAsync(n => n.ItemId == id);

            return result;
        }

        public async Task<Item> UpdateAsync(int id, Item newItem)
        {
            _context.Update(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        }
    }
}
