using Hospital.Data.Entities.HospitalData.DrugStorage;

namespace Hospital.Service.Interfaces
{
	public interface IDrugsService
	{
		Task<Drug> GetDrugByIdAsync(int? productId);
		Task<IReadOnlyList<Drug>> GetAllDrugsAsync();
		Task<IReadOnlyList<DrugType>> GetAllDrugTypesAsync();
		Task<IReadOnlyList<Order>> GetAllOrdersAsync();
	}
}
