namespace Hospital.Repository.Specifications.DrugSpecifications
{
	public class DrugSpecifications
	{
		public int? DrugTypeID { get; set; }

		private string? _Search;
		public string? Sort { get; set; }

		public string? SearchName
		{
			get => _Search;
			set => _Search = value?.Trim().ToLower();
		}
	}
}
