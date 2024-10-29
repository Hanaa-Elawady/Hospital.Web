using Hospital.Data.Entities.HospitalData.DrugStorage;
using Hospital.Repository.Interfaces;
using Hospital.Service.Interfaces;

namespace Hospital.Service.Services
{
	public class DrugService : IDrugsService
	{
		private readonly IUnitOfWork _unitOfWork;

		public DrugService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IReadOnlyList<Drug>> GetAllDrugsAsync()
		=> await _unitOfWork.Repository<Drug>().GetAllAsync();

		public Task<IReadOnlyList<DrugType>> GetAllDrugTypesAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<Order>> GetAllOrdersAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Drug> GetDrugByIdAsync(int? productId)
		{
			throw new NotImplementedException();
		}
	}
}
