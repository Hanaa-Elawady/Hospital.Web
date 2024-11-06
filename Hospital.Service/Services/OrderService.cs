using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Repository.Interfaces;
using Hospital.Service.DTOs;
using Hospital.Service.Interfaces;
using Microsoft.Extensions.Logging;
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
        private readonly IInventoryService inventoryService;
        private readonly ILogger<OrderService> logger;

        public OrderService(IUnitOfWork unitOfWork, IInventoryService inventoryService, ILogger<OrderService> logger)
        {
            this.unitOfWork = unitOfWork;
            this.inventoryService = inventoryService;
            this.logger = logger;
        }

        public async Task<Order> CreateOrder(OrderDetailsDTO orderDetails)
        {
            if (orderDetails == null)
                throw new Exception("All Failds are Required");

            try
            {
                var neworderDetail = new OrderDetail
                {
                    DrugID = orderDetails.DrugID,
                    PricePerUnit = orderDetails.PricePerUnit,
                    Quantity = orderDetails.Quantity,

                };
                var newOrder = new Order
                {
                    SupplierID = orderDetails.SupplierID,
                    DeliveryDate = orderDetails.DeliveryDate,
                    OrderDate = orderDetails.OrderDate,
                    OrderDetails = new List<OrderDetail> { neworderDetail }
                };
                await unitOfWork.Repository<Order>().AddAsync(newOrder);
                await inventoryService.AddToInventory(orderDetails.DrugID, orderDetails.Quantity, orderDetails.InventoryId);
                await unitOfWork.CompleteAsync();

                return newOrder;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
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
