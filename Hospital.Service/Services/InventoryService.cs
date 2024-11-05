using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public InventoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddToInventory(int drugId, int quantity, int? InventoryId)
        {
            if (InventoryId is not null)
            {
                var existInventory = await unitOfWork.Repository<Inventory>().GetByIdAsync(InventoryId);
                if (existInventory is not null)
                {
                    existInventory.DrugID = drugId;
                    existInventory.QuantityInStock += quantity;
                    unitOfWork.Repository<Inventory>().Update(existInventory);
                }
                else
                    throw new Exception($"inventory with id {InventoryId} dosenot exist");
            }
            else
            {
                var newInventory = new Inventory
                {
                    QuantityInStock = quantity,
                    DrugID = drugId
                };
                await unitOfWork.Repository<Inventory>().AddAsync(newInventory);
            }

        }
    }
}
