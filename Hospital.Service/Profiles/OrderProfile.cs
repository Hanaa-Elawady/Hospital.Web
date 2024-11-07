using AutoMapper;
using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() : base()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
        }
    }
}
