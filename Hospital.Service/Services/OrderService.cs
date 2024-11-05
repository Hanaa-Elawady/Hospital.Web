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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork, IInventoryService inventoryService)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(int supplierId, DateTime orderDate, List<OrderDetail> orderDetails)
        {
            if (supplierId <= 0 || orderDetails == null || orderDetails.Count == 0)
            {
                throw new Exception("Invalid supplier ID or order details.");
            }

            Order newOrder = new Order
            {
                SupplierID = supplierId,
                OrderDate = orderDate,

            };

            var inventory = new Inventory();

            foreach (var detail in orderDetails)
            {
                inventory.DrugID = detail.DrugID;
                newOrder.OrderDetails.Add(detail);
            }
            await unitOfWork.Repository<Order>().AddAsync(newOrder);
            await unitOfWork.Repository<Inventory>().AddAsync(inventory);
            await unitOfWork.CompleteAsync();


            return newOrder;
        }

        public async void DeleteOrder(Order order)
        {
            unitOfWork.Repository<Order>().Delete(order);
            await unitOfWork.CompleteAsync();
        }

        public async Task<Order> GetOrderById(int orderid)
        => await unitOfWork.Repository<Order>().GetByIdAsync(orderid);
    }
}
