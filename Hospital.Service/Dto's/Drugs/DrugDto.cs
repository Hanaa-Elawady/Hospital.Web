namespace Hospital.Service.Dto_s.Drugs
{
	public class DrugDto
	{

			public int DrugID { get; set; }
			public string DrugName { get; set; }
			public string Description { get; set; }
			public string Dosage { get; set; }
			public decimal StorageTemperature { get; set; }
			public int DrugTypeID { get; set; }
			public string DrugTypeName { get; set; }
			public int AvailableQuantityInStock { get; set; }


	}
}