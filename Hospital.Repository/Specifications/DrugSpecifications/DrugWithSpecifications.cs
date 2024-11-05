using Hospital.Data.Entities.HospitalData.DrugStorage;

namespace Hospital.Repository.Specifications.DrugSpecifications
{
	public class DrugWithSpecifications : BaseSpecifications<Drug>
	{
		public DrugWithSpecifications(DrugSpecifications specs) 
			: base(Drug =>(!specs.DrugTypeID.HasValue || Drug.DrugTypeID == specs.DrugTypeID.Value)
			 && (string.IsNullOrEmpty(specs.SearchName) || Drug.DrugName.Trim().ToLower().Contains(specs.SearchName))

			)
		{
			AddInclude(x => x.DrugType);
			AddInclude(x => x.Inventories);
		}
	public DrugWithSpecifications(int? id) : base(product => product.DrugID == id)

	{
		AddInclude(x => x.DrugType);
		AddInclude(x => x.Inventories);

	}
	public DrugWithSpecifications(string? name) : base(Drug => string.IsNullOrEmpty(name) || Drug.DrugName.Trim().ToLower().Contains(name))
	{
		AddInclude(x => x.DrugType);
		AddInclude(x => x.Inventories);
	}

	}
}
