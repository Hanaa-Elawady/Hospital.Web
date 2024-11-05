using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IInventoryService
    {
        public Task AddToInventory(int drugId, int quantity, int? InventoryId);

    }
}
