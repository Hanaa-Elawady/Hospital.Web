namespace Hospital.Data.Entities.HospitalData.DrugStorage
{
	public class Inventory
	{
		public int InventoryID { get; set; }
		public int QuantityInStock { get; set; }
		public int AvailableQuantityInStock { get; set; }
		public int ReorderLevel { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string Location { get; set; }


		// Navigation Properties
		public int DrugID { get; set; }
		public Drug Drug { get; set; }
	}
}