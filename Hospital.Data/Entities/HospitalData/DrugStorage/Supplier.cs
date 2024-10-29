namespace Hospital.Data.Entities.HospitalData.DrugStorage
{
	public class Supplier
	{
		public int SupplierID { get; set; }
		public string SupplierName { get; set; }
		public string ContactInfo { get; set; }
		public string Address { get; set; }

		// Navigation Property
		public ICollection<Order> Orders { get; set; }
	}
}