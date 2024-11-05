using Hospital.Data.Entities.HospitalData.DrugStorage;

namespace Hospital.Repository.Specifications.InventorySpecifications
{
	public class InventoryWithSpecification : BaseSpecifications<Inventory>
	{
		public InventoryWithSpecification(InventorySpecification specs)
			: base(Drug => (!specs.DrugID.HasValue || Drug.DrugID == specs.DrugID.Value))
		{
			if (!string.IsNullOrEmpty(specs.Sort))
			{
				switch (specs.Sort)
				{
					case "ExpireDateAsc":
						AddOrderBy(x => x.ExpiryDate);
						break;
					case "ExpireDateDesc":
						AddOrderByDescending(x => x.ExpiryDate);
						break;

					default:
						AddOrderBy(x => x.DrugID);
						break;

				}
			}
		}
		
	}
}
