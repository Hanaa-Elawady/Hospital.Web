using Hospital.Data.Entities.HospitalData.DrugStorage;

namespace Hospital.Repository.Specifications.DrugSpecifications
{
	public class DrugCountWithSpecifications : BaseSpecifications<Drug>
	{
		public DrugCountWithSpecifications(DrugSpecifications specs)
			: base(Drug => (!specs.DrugTypeID.HasValue || Drug.DrugTypeID == specs.DrugTypeID.Value)
			)
		{

		}
	}
}
