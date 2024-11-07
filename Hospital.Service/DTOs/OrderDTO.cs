using Hospital.Data.Entities.HospitalData.DrugStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.DTOs
{
    public class OrderDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        [Required]
        public int SupplierID { get; set; }
        [Required]
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }

    }
}
