using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Repository.Specifications.DrugSpecifications;
using Hospital.Service.Dto_s.Drugs;

namespace Hospital.Service.Interfaces
{
	public interface IDrugsService
	{
		Task<DrugDto> GetByIdAsync(int? Id);
		Task<IReadOnlyList<DrugDto>> GetAllAsync(DrugSpecifications input);
	}
}
