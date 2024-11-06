using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.DTOs
{
    public class OrderDetailsDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime? DeliveryDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal PricePerUnit { get; set; }
        [Required]
        public int SupplierID { get; set; }
        [Required]
        public int DrugID { get; set; }
        public int? InventoryId { get; set; }
    }
}
