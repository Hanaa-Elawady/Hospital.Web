using Hospital.Data.Entities.HospitalData.DrugStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> CreateOrder(int supplierId, DateTime orderDate, List<OrderDetail> orderDetails);
        public void DeleteOrder(Order order);
        public Task<Order> GetOrderById(int orderid);

    }
}
