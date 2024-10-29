namespace Hospital.Data.Entities.HospitalData.DrugStorage
{
	public class OrderDetail
	{
		public int OrderDetailID { get; set; }
		public int Quantity { get; set; }
		public decimal PricePerUnit { get; set; }

		// Navigation Properties
		public int OrderID { get; set; }
		public Order Order { get; set; }
		public int DrugID { get; set; }
		public Drug Drug { get; set; }
	}
}