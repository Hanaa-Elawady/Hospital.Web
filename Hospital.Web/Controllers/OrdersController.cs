using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{

    public class OrdersController : BaseController
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<Order> CreateOrder(int supplierId, DateTime orderDate, List<OrderDetail> orderDetails)
        => await orderService.CreateOrder(supplierId, orderDate, orderDetails);
        [HttpDelete]
        public async void DeleteOrder(Order order)
            => orderService.DeleteOrder(order);
        [HttpGet]
        public async Task<Order> GetOrderById(int orderid)
            => await orderService.GetOrderById(orderid);
    }
}
