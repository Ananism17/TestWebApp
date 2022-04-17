using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApp.Models;

namespace TestWebApp.Data.Services
{
        public interface IItemsService
{
        Task<IEnumerable<Item>> GetAllAsync();

        Task<Item> GetByIdAsync(int id);

        Task AddAsync(Item item);
        
        Task<Item> UpdateAsync(int id, Item newItem);

        void Delete(int id);
    }
}
