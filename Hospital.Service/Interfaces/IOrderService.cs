using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDTO> CreateOrder(OrderDTO order);
        public void DeleteOrder(Order order);
        public Task<Order> GetOrderById(int orderid);

    }
}
