namespace Hospital.Data.Entities.HospitalData.DrugStorage
{
	public class DrugType
	{
		public int DrugTypeID { get; set; }
		public string DrugTypeName { get; set; }
		public ICollection<Drug> Drugs { get; set; }
	}
}