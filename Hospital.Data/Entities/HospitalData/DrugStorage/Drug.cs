namespace Hospital.Data.Entities.HospitalData.DrugStorage
{
	public class Drug
	{
		public int DrugID { get; set; }
		public string DrugName { get; set; }
		public string Description { get; set; }
		public string Dosage { get; set; }
		public decimal StorageTemperature { get; set; }

		// Navigation Properties
		public int DrugTypeID { get; set; }
		public DrugType DrugType { get; set; }
		public ICollection<Inventory> Inventories { get; set; }
		public ICollection<OrderDetail> OrderDetails { get; set; }
	
	}
}
