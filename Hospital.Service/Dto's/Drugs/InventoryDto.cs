namespace Hospital.Service.Dto_s.Drugs
{
	public class InventoryDto
	{
		public int InventoryID { get; set; }
		public int QuantityInStock { get; set; }
		public int AvailableQuantityInStock { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
