using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Service.DTOs;
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
        public async Task<OrderDTO> CreateOrder([FromBody] OrderDTO order)
        => await orderService.CreateOrder(order);
        [HttpDelete]
        public async void DeleteOrder(Order order)
            => orderService.DeleteOrder(order);
        [HttpGet]
        public async Task<Order> GetOrderById(int orderid)
            => await orderService.GetOrderById(orderid);
    }
}
