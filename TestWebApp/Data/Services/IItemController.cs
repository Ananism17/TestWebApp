using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Data.Services
{
    public class IItemController
    {
        Task<IEnumerable<Item>> GetAll();

        Item GetById(int id);

        void Add(Item item);

        Item Update(int id, Item newItem);

        void Delete(int id);
    }
}
