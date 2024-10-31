using Hospital.Data.Entities.HospitalData.DrugStorage;

namespace Hospital.Repository.Specifications.DrugSpecifications
{
	public class DrugWithSpecifications : BaseSpecifications<Drug>
	{
		public DrugWithSpecifications(DrugSpecifications specs) 
			: base(Drug =>(!specs.DrugTypeID.HasValue || Drug.DrugTypeID == specs.DrugTypeID.Value)
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
	}
}
