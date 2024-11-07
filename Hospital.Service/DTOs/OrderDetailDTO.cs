namespace Hospital.Service.DTOs
{
    public class OrderDetailDTO
    {
        public int DrugID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }

        public decimal PricePerUnit { get; set; }
    }
}