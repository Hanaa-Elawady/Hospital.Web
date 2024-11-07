using AutoMapper;
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
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IInventoryService inventoryService, ILogger<OrderService> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.inventoryService = inventoryService;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO order)
        {


            try
            {

                var neworder = mapper.Map<Order>(order);
                await unitOfWork.Repository<Order>().AddAsync(neworder);
                await unitOfWork.CompleteAsync();

                return mapper.Map<OrderDTO>(neworder);
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
