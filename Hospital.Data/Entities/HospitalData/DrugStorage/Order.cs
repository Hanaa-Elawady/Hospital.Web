namespace Hospital.Data.Entities.HospitalData.DrugStorage
{
	public class Order
	{
		public int OrderID { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime? DeliveryDate { get; set; }

		// Navigation Properties
		public int SupplierID { get; set; }
		public Supplier Supplier { get; set; }
		public ICollection<OrderDetail> OrderDetails { get; set; }
	}
}